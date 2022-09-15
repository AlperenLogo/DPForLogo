// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Bir nesne ...... olmadan çalışmıyor ise o ....... ' dependent'dir.

public class ReportService
{
    ISender sender;

    public ReportService(ISender sender)
    {
        sender = sender;
    }
    public void Send()
    {

        sender.Send();
    }

    public void DoSomething()
    {
        sender.Send();

    }
}


public interface ISender
{
    void Send();
}
public class MailSender : ISender
{
    public void Send() => Console.WriteLine("Mail gönderildi");
}

public class WhatsappSender : ISender
{
    public void Send()
    {
        Console.WriteLine("WS ile gönderildi");
    }
}


