Luca.EmailConfiguration conf = new Luca.EmailConfiguration();
MimeKit.MimeMessage ma = new MimeKit.MimeMessage();

conf.SmtpServer = "smtp.gmail.com";
conf.SmtpPort = 465;
conf.SmtpUsername = "wmori.luca@gmail.com";
conf.SmtpPassword = "****";



#region sendEmail
try
{
    Luca.EmailService s = new Luca.EmailService(conf);
    List<Luca.EmailAddress> l = new List<Luca.EmailAddress>()
	{
		new Luca.EmailAddress()
		{
			Name = "Robot Poliplast",
			Address = "Robottino@Poliplast.com"
		}
	};
		List<Luca.EmailAddress> lt = new List<Luca.EmailAddress>()
	{
		new Luca.EmailAddress()
		{
			Name = "Luca Mori",
			Address = "luca.mori@gidiautomazione.it"
		}
	};

    Luca.EmailMessage m = new Luca.EmailMessage()
    {
        Subject = "NuovoPezzoProdotto",
        Content = "<h1>Prodotto nuovo Pezzo</h1>" +
            $"<p>Orario : {p.OraLog}</p>" +
            $"<p>Stazione : {p.Stazione}</p>" +
            $"<p>TempoLavorazione : {p.TempoCiclo}</p>",
        FromAddresses = l,
        ToAddresses = lt
    };

    s.Send(m);
}
catch (Exception ex)
{
    _log.WriteLog("Errore invio email Produzione : "+ex.Message);
}
#endregion