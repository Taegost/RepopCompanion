# RepopCompanion
This is a simple web app companion for the game The Repopulation (https://therepopulation.com/) to pull data from the in-game database and display it in an easy-to-view format.
It was inspired by the excellent CraftMap site (http://aena.at/craftmap/craftmap.html).
To view the latest Dev build of the site, please visit http://repopcompaniondev.azurewebsites.net/
It is still quite a ways away from feature complete and needs a serious styling overhaul, so please bear with us as we get it off the ground.
To contribute, please start in the "Prerequisites" folder for any framework and tool installs necessary.

NOTE: If you have an issue with it not recognizing the Entity Framework objects, take the following steps:

1) Open App_Code\SqliteEF6Models\RepopSqliteEF6Model.edmx (Requires you to have performed the pre-requisite installations)
2) Right-click in a blank spot and choose 'Update model from database'
3) Accept the defaults and click 'Next' until the wizard finishes
4) Find and replace all cases where the namespace is "SqliteEF6Models" with "Repop_Companion.DataModels" (without the quotes) in the following files:
   - \App_Code\SqliteEF6Models\RepopSqliteEF6Model.Context.tt\RepopSqliteEF6Model.Context.cs
   - \App_Code\SqliteEF6Models\RepopSqliteEF6Model.tt\RepopSqliteEF6Model.cs
