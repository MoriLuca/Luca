#esempio utilizzo logger

#dopo aver istanziato una classe logger
	Luca.Logs.Logger log = new Luca.Logs.Logger();

#assegnare alla proprietà LogFolder il nome della cartella da utilizzare per i prossimi log
	log.LogFolder = "TestLucaLogs";
	
#a questo punto possiamo andare a salvare il log, passando come parametro una stringa alla funzione WriteLog
	log.WriteLog("Ecco il mio promo log");
	Console.ReadLine();