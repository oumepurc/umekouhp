using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace umekou.Controllers
{
    public class EcoclubController : Controller
    {
        //
        // GET: /Ecoclub/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Nyuukai()
        {
            return View();
        }

        public ActionResult Kiyaku()
        {
            return View();
        }

        public ActionResult Reason()
        {
            return View();
        }

        public ActionResult Toiawase()
        {
            return View();
        }


        public ActionResult Form(ecoClubInfo info)
        {
            if (Request.HttpMethod == "GET")
            {
                // HTTP GET経由で呼び出された場合の処理
            }
            else
            {
                // HTTP POST経由で呼び出された場合の処理
            }
 
            return View(info);
        }

        public ActionResult FormToiawase(ecoClubToiawase info)
        {
            if (Request.HttpMethod == "GET")
            {
                // HTTP GET経由で呼び出された場合の処理
            }
            else
            {
                // HTTP POST経由で呼び出された場合の処理
            }

            return View(info);
        }



        public ActionResult Confirm(ecoClubInfo info)
        {
            if (Request.HttpMethod == "GET")
            {
                // HTTP GET経由で呼び出された場合の処理
            }
            else
            {
                // HTTP POST経由で呼び出された場合の処理
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                //送信者
                msg.From = new System.Net.Mail.MailAddress("system@umekou.net", "うめ校HPのシステムより");
                //宛先
                msg.To.Add(new System.Net.Mail.MailAddress("oume.purc@gmail.com", "うめ校様"));
                //件名
                msg.Subject = "■■おうめこどもエコクラブ入会申し込み";
                //本文
                msg.Body += "▼以下の情報でおうめこどもエコクラブへの入会申し込みがありました";
                msg.Body +="お子様のお名前："+ info.child_name+"\r\n\r\n";
                msg.Body += "ふりがな：" + info.child_name_furigana + "\r\n\r\n";
                msg.Body += "学年、年齢：" + info.state + "\r\n\r\n";
                msg.Body += "電話番号：" + info.tel + "\r\n\r\n";
                msg.Body += "FAX：" + info.fax + "\r\n\r\n";
                msg.Body += "メールアドレス：" + info.email + "\r\n\r\n";

                System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient(); 
                sc.Host = "mail.umekou.expressweb.jp";
                sc.Credentials = new System.Net.NetworkCredential("system@umekou.net", "Umekoudane@1");
                sc.EnableSsl = false;
                sc.Timeout = 100000;

                sc.Send(msg);
                msg.Dispose();


                //申込者宛------------------------------------------
                System.Net.Mail.MailMessage msg_toClient = new System.Net.Mail.MailMessage();
                //送信者
                msg_toClient.From = new System.Net.Mail.MailAddress("system@umekou.net", "うめ校HPのシステムより");
                //宛先
                msg_toClient.To.Add(new System.Net.Mail.MailAddress(info.email, "保護者様"));
                //件名
                msg_toClient.Subject = "■■おうめこどもエコクラブへの入会申し込みを受付けました";
                //本文
                msg_toClient.Body += "おうめこどもエコクラブへの入会申し込みありがとうございます。" + "\r\n";
                msg_toClient.Body += "後ほどスタッフから返信させて頂きますので、しばらくお待ち下さい。" + "\r\n";
                msg_toClient.Body += "※oume.purc@gmail.comからのメールが受信できるようお願いいたします。" + "\r\n\r\n";
                msg_toClient.Body += "\r\n\r\n";
                msg_toClient.Body += "お子様のお名前：" + info.child_name + "\r\n\r\n";
                msg_toClient.Body += "ふりがな：" + info.child_name_furigana + "\r\n\r\n";
                msg_toClient.Body += "学年、年齢：" + info.state + "\r\n\r\n";
                msg_toClient.Body += "電話番号：" + info.tel + "\r\n\r\n";
                msg_toClient.Body += "FAX：" + info.fax + "\r\n\r\n";
                msg_toClient.Body += "メールアドレス：" + info.email + "\r\n\r\n";

                System.Net.Mail.SmtpClient sc_toClient = new System.Net.Mail.SmtpClient();
                sc_toClient.Host = "mail.umekou.expressweb.jp";
                sc_toClient.Credentials = new System.Net.NetworkCredential("system@umekou.net", "Umekoudane@1");
                sc_toClient.EnableSsl = false;
                sc_toClient.Timeout = 100000;

                sc_toClient.Send(msg_toClient);
                msg_toClient.Dispose();

            }

            return View(info);
        }

        public ActionResult ConfirmToiawase(ecoClubToiawase info)
        {
            if (Request.HttpMethod == "GET")
            {
                // HTTP GET経由で呼び出された場合の処理
            }
            else
            {
                // HTTP POST経由で呼び出された場合の処理
                //うめ校宛------------------------------------------
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                //送信者
                msg.From = new System.Net.Mail.MailAddress("system@umekou.net", "うめ校HPのシステムより");
                //宛先
                msg.To.Add(new System.Net.Mail.MailAddress("oume.purc@gmail.com", "うめ校様"));
                //件名
                msg.Subject = "■■おうめこどもエコクラブへの問い合わせ";
                //本文
                msg.Body += "▼以下の情報でおうめこどもエコクラブへ問い合わせがありました";
                msg.Body += "氏名：" + info.toiawase_name + "\r\n\r\n";
                msg.Body += "電話番号：" + info.toiawase_tel + "\r\n\r\n";
                msg.Body += "メールアドレス：" + info.toiawase_email + "\r\n\r\n";
                msg.Body += "問い合わせ内容：" + "\r\n\r\n";
                msg.Body += "" + info.toiawase_txt + "\r\n\r\n";

                System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient();
                sc.Host = "mail.umekou.expressweb.jp";
                sc.Credentials = new System.Net.NetworkCredential("system@umekou.net", "Umekoudane@1");
                sc.EnableSsl = false;
                sc.Timeout = 100000;
                sc.Send(msg);
                msg.Dispose();

                //申込者宛------------------------------------------
                System.Net.Mail.MailMessage msg_toClient = new System.Net.Mail.MailMessage();
                //送信者
                msg_toClient.From = new System.Net.Mail.MailAddress("system@umekou.net", "うめ校HPのシステムより");
                //宛先
                msg_toClient.To.Add(new System.Net.Mail.MailAddress(info.toiawase_email, info.toiawase_name + "様"));
                //件名
                msg_toClient.Subject = "■■おうめこどもエコクラブへのお問い合わせを受け付けました";
                //本文
                msg_toClient.Body += "▼以下の情報でおうめこどもエコクラブへのお問い合わせを受け付けました。" + "\r\n";
                msg_toClient.Body += "後ほどスタッフから返信させて頂きます。" + "\r\n";
                msg_toClient.Body += "※oume.purc@gmail.comからのメールが受信できるようお願いいたします。" + "\r\n\r\n";
                msg_toClient.Body += "氏名：" + info.toiawase_name + "\r\n\r\n";
                msg_toClient.Body += "電話番号：" + info.toiawase_tel + "\r\n\r\n";
                msg_toClient.Body += "メールアドレス：" + info.toiawase_email + "\r\n\r\n";
                msg_toClient.Body += "問い合わせ内容：" + "\r\n\r\n";
                msg_toClient.Body += "" + info.toiawase_txt + "\r\n\r\n";

                System.Net.Mail.SmtpClient sc_toClient = new System.Net.Mail.SmtpClient();
                sc_toClient.Host = "mail.umekou.expressweb.jp";
                sc_toClient.Credentials = new System.Net.NetworkCredential("system@umekou.net", "Umekoudane@1");
                sc_toClient.EnableSsl = false;
                sc_toClient.Timeout = 100000;
                sc_toClient.Send(msg_toClient);
                msg_toClient.Dispose();

            }

            return View();
        }




    }

    public class ecoClubInfo
    {
        public string child_name { get; set; }
        public string child_name_furigana { get; set; }
        public string tel { get; set; }
        public string fax { get; set; }
        public string school_name { get; set; }
        public string class_year { get; set; }
        public string hoikuen_name { get; set; }
        public string age { get; set; }

        public string state { get{
            string str = "";
            if (rdoState == "school")
            {
                str = school_name + " (" + class_year + ")";

            }
            if (rdoState == "preSchool")
            {
                str = "未就学児 " + hoikuen_name + " (" + age + ")";

            }

            return str;
        
        }}
       
        public string email { get; set; }

        public string rdoState { get; set; }

    }

    public class ecoClubToiawase
    {
        public string toiawase_name { get; set; }
        public string toiawase_tel { get; set; }
        public string toiawase_email { get; set; }
        public string toiawase_txt { get; set; }
       
    }
}
