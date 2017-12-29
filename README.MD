#ChangePlayer

umgesetzt sind:
__GameController, der bisher noch nichts macht, außer eine Runde zu starten
__RoundController: Minimalversion des Spieler-Wechsels; dzt. ist es so: das Hinlegen der Karte muss man sich denken, dann drückt man auf "Change Player" und gibt das Handy weiter; der Spieler, der als letztes am Zug war drückt auf "End Round"; danach wird eine neue Runde gestartet, wobei der Spieler, der als erster am Zug ist, zufällig ausgewählt wird; die Spielername ist jeweils der Index im Array, die "Karte" einfach nur mal ein Integer, der bei jedem Spieler anders ist

Natürlich muss ich das erst in unser Projekt einbauen, aber das Grundprinzip müsste jedenfalls mal so passen.