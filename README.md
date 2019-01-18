# InMemoryLoader

InMemoryLoader ist eine in C# (Mono) geschriebene Funktions- oder Klassen-Bibliothek die das dynamische Laden von .NET Assemblies zur Laufzeit ermöglicht.

[Link zum Urheber/Blog](https://blog.responsive-kaysta.ch/post/inmemoryloader)

Das Projekt "InMemoryLoader" ist aus einer Anforderung oder Idee entstanden, ein möglichst modulares Web-Framework für Business-Anwendungen zu entwickeln. Es mussten unterschiedlichste Technologien (ASP Web-Sites, SAP Dienste, Web-Service, CMS Systeme, unterschiedliche Datenbanken) kombiniert bzw. Daten aus diesen Systemen in einer Applikation kombiniert werden.

Damit die einzelnen Anwendungen modular, schlank und einfach wartbar blieben, mussten die einzelnen Bestandteile in einzelne Module aufgeteilt werden. Die einzelnen Module mussten verknüpf oder kombinierbar sein weshalb ein Modul entwickelt wurde, dass die Verwaltung, Registrierung und Ausführung ermöglicht.

Die Komponenten müssen ein Interface implementieren woraufhin die Initialisierungsmethode prüft und alle öffentlichen Methoden in einer Art „Registry“ einträgt und so zur Laufzeit im Kontext der Anwendung komplett erhalten bleiben.
So werden sehr effiziente Applikationen ohne fixe Referenzen möglich, das Projekt kann so viel schlanker und effizienter gehalten werden. Zudem kann zur Laufzeit sehr einfach Funktionalität hinzugefügt werden und so die Startup-Time von Anwendungen massiv verkürzen.

Ein weiterer Vorteil besteht darin, dass so verschiedene Funktionscontainer erstellt werden können.

Beispiel

Bei einer Anwendung kann zuerst die Rolle des Benutzers abgefragt werden und danach die entsprechende Bibliothek/Komponenten dynamisch nachgeladen werden. Dies erhöht nicht nur die Performance, die Funktionen stehen so auch nur dem jeweiligen Kontext zur Verfügung wodurch die Anwendungen sicherer werden.

## Bestandteile

### InMemoryLoaderBase

Komponente die eine abstrakte Klasse enthält die implementiert werden muss. Sie dient der Initialisierung und enthält ansonsten keinerlei notwendige Funktion.

### InMemoryLoader

Der Kern einer InMemoryLoader-Anwendung, sie enthält alle benötigten Methoden und Properties die zum Aufbau benötigt werden.

### InMemoryLoaderCommon

Erweiterung die zusätzliche Funktionen wie einen Async-Wrapper, Crypt-Tools, String-Utilities und Converter enthält. Wird NICHT zwingend benötigt!
