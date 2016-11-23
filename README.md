## A Simple WPF Architecture Demo

Some years ago I wrote an [article](http://www.devmedia.com.br/mandamentos-da-orientacao-a-objetos-artigo-net-magazine-79/18481) for [DevMedia group](http://www.devmedia.com.br/) named "Comandments of Object Orientation", based in what I'd worked, learned, read, and studied. So I can say:

_The goal of this project is to show how build a good (flexible) solution for WPF applications._

Well, this is not a silver bullet, but it's a starting point and I'd like to let an open discussion here.

![](http://g.recordit.co/OKOhx9TYTx.gif "Simple application")

## What you can see
- How to keep logic in ViewModel, avoiding code-behind
- Use commands to abstract user actions
- Dispatch specific messages (message mediator pattern) to accomplish specific actions
- UI message services
- Program to interface, not implementation
- Model validation
- NHibernate (in a simple way)
- Mapping Models->Entities and Entities<-Models

In the next days I'm creating some wikis explaining the code 

## What is inside

This is an one Window only application using the following packages: 

- MVVMHelper, a MVVM framework I like (binaries included).
- [Material Design](http://materialdesigninxaml.net/) UI style.
- [Castle Windsor](http://www.castleproject.org/) Inversion of Control container.
- [NHibernate](http://nhibernate.info/) for data persistance.
- [Fluent NHibernate](http://www.fluentnhibernate.org/) for class mapping.
- [SQLite](https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki) as database.
- [AutoMapper](http://automapper.org/) for mapping one object to another (Models to Entities/Entities to Models).
- [NUnit](http://nunit.org/) for some unit tests.

All packages available by nuget, except MVVMHelper (binaries included)

##Instructions

As SQLite database is not created, open App.xml.cs and change this line:

SessionFactory = Bootstrapper.Initialize(false);

to

SessionFactory = Bootstrapper.Initialize(true);

and run the application,
so database will be created.

After first run you can change back to


SessionFactory = Bootstrapper.Initialize(false);

