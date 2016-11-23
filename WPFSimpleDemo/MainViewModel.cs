using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using JulMar.Core.Interfaces;
using JulMar.Windows.Interfaces;
using JulMar.Windows.Mvvm;
using NHibernate.Linq;
using WPFSimpleDemo.Entities;
using WPFSimpleDemo.Helpers;
using WPFSimpleDemo.Messages;
using WPFSimpleDemo.Model;

namespace WPFSimpleDemo
{
    public class MainViewModel : ViewModel
    {
        private UserModel _user;
        private UserModel _selectedUser;
        private BindingListSortable<UserModel> _userList;
        private bool _isBusy;
        private bool _isEditing;

        public DelegatingCommand CmdInsert { get; set; }
        public DelegatingCommand CmdEdit { get; set; }
        public DelegatingCommand CmdCancel { get; set; }
        public DelegatingCommand CmdDelete { get; set; }
        public DelegatingCommand CmdSave { get; set; }


        public MainViewModel()
        {
            CmdInsert = new DelegatingCommand(DoInsert, CanDoInsert);
            CmdEdit = new DelegatingCommand(DoEdit, CanDoEdit);
            CmdCancel = new DelegatingCommand(DoCancel, CandDoCancel);
            CmdDelete = new DelegatingCommand(DoDelete, CanDoDelete);
            CmdSave = new DelegatingCommand(DoSave, CanDoSave);
            LoadUsers();
        }

        private void LoadUsers()
        {
            var list = new List<User>();
            using (var session = App.SessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        list = session.Query<User>().ToList();
                        tx.Commit();
                    }
                    catch (Exception)
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
            UserList = new BindingListSortable<UserModel>(Bootstrapper.Mapper.Map<List<User>, List<UserModel>>(list));
        }


        public UserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(() => User);
            }
        }

        public UserModel SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(() => SelectedUser);
                if (!IsEditing)
                    User = SelectedUser;

            }
        }

        public BindingListSortable<UserModel> UserList
        {
            get { return _userList; }
            set
            {
                _userList = value;
                OnPropertyChanged(() => UserList);
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged(() => IsBusy);
            }
        }

        public bool IsEditing
        {
            get { return _isEditing; }
            set
            {
                _isEditing = value;
                OnPropertyChanged(() => IsEditing);
                if (_isEditing)
                    Resolve<IMessageMediator>()
                        .SendMessage(Constants.Messages.EditMessage, new EditMessage() {ViewModel = this});
            }
        }


        private void DoInsert()
        {
            IsEditing = true;
            User = new UserModel();
            User.BeginEdit();
        }

        private bool CanDoInsert()
        {
            return !IsBusy && !IsEditing;
        }

        private void DoEdit()
        {
            IsEditing = true;
            User.BeginEdit();
        }

        private bool CanDoEdit()
        {
            return !IsBusy && !IsEditing && User != null && User.Id > 0;
        }

        private void DoCancel()
        {
            User.CancelEdit();
            IsEditing = false;
        }

        private bool CandDoCancel()
        {
            return !IsBusy && IsEditing && User != null;
        }

        private void DoDelete()
        {
            if (Resolve<IMessageVisualizer>().Show("Attention", "Delete selected user?", MessageButtons.YesNo) ==
                MessageResult.No)
                return;

            using (var session = App.SessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        var user = Bootstrapper.Mapper.Map<UserModel, User>(User);
                        session.Delete(user);
                        tx.Commit();
                        UserList.Remove(User);
                        UserList.ResetBindings();
                        User = new UserModel();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        Resolve<IMessageVisualizer>().Show("Error", ex.Message, MessageButtons.OK);
                    }
                }
            }
        }

        private bool CanDoDelete()
        {
            return !IsBusy && !IsEditing && User != null;
        }

        private void DoSave()
        {
            try
            {
                var user = Bootstrapper.Mapper.Map<UserModel, User>(User);
                using (var session = App.SessionFactory.OpenSession())
                {
                    using (var tx = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(user);
                        try
                        {
                            tx.Commit();
                        }
                        catch (Exception)
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }

                User.Id = user.Id;
                User.EndEdit();
                UserList.Add(User);
                UserList.ResetBindings();
                IsEditing = false;
            }
            catch (Exception ex)
            {
                Resolve<IMessageVisualizer>().Show("Error", ex.Message, MessageButtons.OK);
            }
        }

        private bool CanDoSave()
        {
            return !IsBusy && IsEditing && User!=null && User.IsValid;
        }

    }
}
