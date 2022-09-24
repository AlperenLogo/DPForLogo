// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
 * Problem:
 * 
 * Bir iş akışı, birden fazla koşulu değerlendirerek sağlanmaktadır. Koşullar zamanla artabilir durumdaysa; bu akış nasıl yönetilebilir?
 * Çalışan; izin alacak... Her iki-üç gün ise; yönetici onayı yeterli. Bir hafta departman.... Bir haftadan fazla İK onayı...
 * 
 * CoR: Bir akıştaki sorumluluğu birkaç nesneye ayırarak bir zincir oluştur. Zincirin her halkası bir sorumluluğu icra etsin. Gelen her talep, en baştan başlasın; adım adım halkaları dolaşsın.
 * 
 */
ISO14001 iso14001 = new ISO14001();
ISO27001 iSO27001 = new ISO27001();
ISO9001 iSO9001 = new ISO9001();

iso14001.Next = iSO27001;
iSO27001.Next = iSO9001;

CertificateRequest request = new CertificateRequest { Name = "ISO9001" };

iso14001.Confirm(request);


public class CertificateRequest
{
    public string Name { get; set; }
}
public class CertificateRequestEventArs : EventArgs
{
    public CertificateRequest Request { get; set; }
}

public abstract class Responsible
{
    public Responsible Next { get; set; }
    public EventHandler<CertificateRequestEventArs> CertificateRequestConfirm;

    public abstract void Certificate_Confirm(object sender, CertificateRequestEventArs e);
    public Responsible()
    {
        CertificateRequestConfirm += Certificate_Confirm;
    }

    public void Confirm(CertificateRequest certificateRequest)
    {
        if (CertificateRequestConfirm != null)
        {
            CertificateRequestConfirm(this, new CertificateRequestEventArs { Request = certificateRequest });
        }
    }
}

public class ISO14001 : Responsible
{
    public override void Certificate_Confirm(object sender, CertificateRequestEventArs e)
    {
        if (e.Request.Name == "ISO14001")
        {
            Console.WriteLine($"talep onaylandı... {e.Request.Name} işlemleri yapılıyor ");
        }
        else
        {
            Next.CertificateRequestConfirm(this, e);
        }
    }
}

public class ISO27001 : Responsible
{
    public override void Certificate_Confirm(object sender, CertificateRequestEventArs e)
    {
        if (e.Request.Name == "ISO27001")
        {
            Console.WriteLine($"talep onaylandı... {e.Request.Name} işlemleri yapılıyor ");
        }
        else
        {
            Next.CertificateRequestConfirm(this, e);
        }
    }
}

public class ISO9001 : Responsible
{
    public override void Certificate_Confirm(object sender, CertificateRequestEventArs e)
    {
        if (e.Request.Name == "ISO9001")
        {
            Console.WriteLine($"talep onaylandı... {e.Request.Name} işlemleri yapılıyor ");
        }
        else
        {
            Console.WriteLine("Uygun sertifika yok. İşlem reddedildi");
        }
    }
}