// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
/*
 * Problem:
 * Miras yoluyla geliştirme yapmanın anlamsız olduğu bir senaryoda bu sınıflara DOKUNMADAN geliştirmeyi nasıl sağlarım.
 * 
 * Senaryo:
 *    Kahve (Filtre, Espresso)
 *    
 *    var kahve = new Kahve();
 *    var latte = new Latte(kahve);
 *    var karamelli = new Karamel(latte);
 *    
 *    
 
 *.NET nasıl kullanıyor?
 *
 */
//var stream = new FileStream("", FileMode.CreateNew);
//var zipped = new GZipStream(stream, CompressionMode.Compress);
//var crypted = new CryptoStream(zipped, null, CryptoStreamMode.Write);


var mail = new WorkMail();
var signed = new SignedMail(mail);
var secure = new SecureMail(signed);

secure.Send();



public interface IMail
{
    void Send();
}
public class WorkMail : IMail
{
    public string Body { get; set; }
    public void Send()
    {
        Console.WriteLine("mail gönderildi");
    }
}

public class SignedMail : IMail
{
    private readonly IMail mail;

    public SignedMail(IMail mail)
    {
        this.mail = mail;
    }
    public void AddSign()
    {
        Console.WriteLine("Mail imzalandı");
    }
    public void Send()
    {

        AddSign();
        mail.Send();

    }
}


public class SecureMail : IMail
{
    private readonly IMail mail;

    public SecureMail(IMail mail)
    {
        this.mail = mail;
    }

    public void AddSecure()
    {
        Console.WriteLine("Güvenlik koşulları eklendi...");
    }

    public void Send()
    {
        AddSecure();
        mail.Send();
    }
}
