# InMemoryLoader 
## Einführung

Das Projekt "InMemoryLoader" ist aus einer Anforderung oder Idee entstanden, ein möglichst modulares Web-Framework für Business-Anwendungen zu entwickeln.

Ich musste unterschiedlichste Technologien (ASP Web-Sites, SAP Dienste, Web-Service, CMS Systeme) kombinieren bzw. Daten anziehen und verarbeiten.

[Link](http://www.leica-geosystems.ch/de/index.htm) zur Firmen-Webseite (Leica Geosystems)

## Beschreibung
InMemoryLoader ist eine in C# (Mono) geschriebene Funktions- oder Klassen-Bibliothek die das dynamische Laden von .NET Assemblies zur Laufzeit ermöglicht ohne eine Referenz in der Project-Solution vorauszusetzen. 

Im Wesentlichen besteht sie aus zwei nuget-Packages die mit Mono entwickelt wurden und so über Plattformgrenzen hinweg verwendet werden können. 

[Link](https://www.nuget.org/packages/InMemoryLoader/) zu InMemoryLoader auf nuget.org 
[Link](https://www.nuget.org/packages/InMemoryLoaderBase/) zu InMemoryLoaderBase auf nuget.org

Hierbei werden die .Dll’s einmalig geladen und geprüft, in eine Collection geschrieben und zur Laufzeit einmalig instanziiert und im Memory gespeichert.

So werden sehr effiziente Applikationen ohne fixe Referenzen möglich, das Projekt kann so viel schlanker und effizienter gehalten werden. Zudem kann zur Laufzeit sehr einfach Funktionalität hinzugefügt werden und so die Startup-Time von Anwendungen massiv verkürzen.

Ein weitere Vorteil besteht darin, dass so verschiedene Funktionscontainer erstellt werden können. Bsp.: je nach User-Context können so verschiedene Funktionen angeboten werden. Dies erhöht nicht nur die Performance, die Funktionen stehen so auch nur dem jeweiligen Context zur Verfügung was die Sicherheit ebenfalls positiv beeinflusst.

## Status

InMemoryLoader befindet sich (noch) im frühen Entwicklungsstadium, kann jedoch ohne weiteres eingesetzt werden da die Grundfunktionen ausgereift und stabil sind.

## Getting started
### Projektsetup, einfaches CMD Programm

Es steht ein einfaches CMD-Programm zur Verfügung welches auf einfache Art und Weise die Funktionsweise darstellt. Ich verzichte hier auf ein aufwendiges how-to da der Code einfach ist und sich selbst beschreibt.

[Link](http://responsive-kaysta.ch/InMemoryLoader/InMemoryLoaderTestConsole.zip) zum Beispielprojekt

### InMemoryLoader

Der Kern des ganzen ist InMemoryLoader, in dieser Bibliothek werden verschiedene Funktionen angeboten um .Dll's zu prüfen, laden und registrieren. Das Packet benötigt InMemoryLoaderBase und log4net.

### InMemoryLoaderBase 

InMemoryLoaderBase beinhaltet Interfaces und abstrakte Klassen die im Basispacket zwingend benötigt werden.

### InMemoryLoaderCommon

Eine Sammlung recht hilfreicher Utilities für String-Operationen, Datum- und Konvertierungs-Funktionen, Check- und Crypt-Funktionen etc.

## Abhängigkeiten

InMemoryLoader benötigt InMemoryLoaderBase, dieses Package enthält verschiedene Interfaces und abstrakte Klassen ohne die der Loader nicht funktioniert. Es handelt sich hierbei um reine Hilfsmittel.

[Link](https://www.nuget.org/packages/InMemoryLoader/) zu InMemoryLoader auf nuget.org 
[Link](https://www.nuget.org/packages/InMemoryLoaderBase/) zu InMemoryLoaderBase auf nuget.org

Zudem setzt InMemoryLoader/Base log4net zur Protokollierung ein, die entsprechende(n) Bibliothek(en) werden mit dem nuget-Package ausgeliefert.

[Link](https://www.nuget.org/packages/log4net/) zu log4net