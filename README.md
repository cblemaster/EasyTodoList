# EasyTodoList
## About
+ An application that provides todo functionality, nothing fancy, just the basics
+ Inspired by, but not strictly adherent to, my understanding of domain driven design concepts, clean architecture, and SOLID principles
+ The app will start small, with new features added incrementally
## Objectives
+ Start with a simple but elegant domain model derived from the use cases and rules
+ Develop a layered architecture inspired by domain-driven design
+ Make the app extensible so that adding features is easy
+ Avoid 'complexity for complexity's sake'
+ Identify what I am learning along the way
## Use cases
|#|Use case|Description|
|-|-|-|
|1|See all todos|As a user, I want to see an interactive list of my todos<br />All information related to a todo should be available in this view<br />The list should be sorted by due date desc, then description<br />This list excludes completed todos, which are visible elsewhere|
|2|See due today todos|As a user, I want to see an interactive list of my todos that are due today<br />All information related to a todo should be available in this view<br />The list should be sorted by description<br />This list excludes completed todos, which are visible elsewhere|
|3|See important todos|As a user, I want to see an interactive list of my todos that are important<br />All information related to a todo should be available in this view<br />The list should be sorted by due date desc, then description<br />This list excludes completed todos, which are visible elsewhere|
|4|See completed todos|As a user, I want to see an interactive list of my todos that are complete<br />All information related to a todo should be available in this view<br />The list should be sorted by due date desc, then description|
|5|See overdue todos|As a user, I want to see an interactive list of my todos that are due prior to today<br />All information related to a todo should be available in this view<br />The list should be sorted by due date desc, then description<br />This list excludes completed todos, which are visible elsewhere|
|6|Create todo|As a user, I want to create todos<br />The description for the new todo is required, cannot be all whitespace characters, and must be 100 or fewer characters in length<br />The due date for the new todo is optional, and if provided can be past, present, or future<br />The create date for the new todo is set and never subsequently modified|
|7|Update todo|As a user, I want to update todos<br />I want to be able to update the todo decription and/or the due date<br />The description for the todo is required, cannot be all whitespace characters, and must be 100 or fewer characters in length<br />The due date for the todo is optional, and if provided can be past, present, or future<br />Completed todos cannot be updated, except to toggle back to incomplete<br />The update date for the todo is set |
|8|Toggle todo importance|As a user, I want to update the importance of todos<br />Completed todos cannot be updated, except to toggle back to incomplete<br />The update date for the todo is set|
|9|Toggle todo completion|As a user, I want to update the completion of todos<br />The update date for the todo is set|
|10|Delete todo|As a user, I want to delete todos<br />Important todos cannot be deleted|
## App architecture
### Presentation
+ The user interface for the application
+ Commands and queries for use cases are triggered from here
### Application
+ Objects and service classes that implement the use cases+ 
### Infrastructure
+ Anything not part of the application's core functionality, e.g., logging, messaging, data access, external integrations
### Domain
+ Object modeling of the application's entities, data and rules
## Built with
+ .NET 9/ C# 13
+ Microsoft Visual Studio Community 2022
