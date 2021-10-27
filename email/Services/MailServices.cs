using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using email.Dal;
using email.Models;


namespace email.Services
{
    public class MailServices
    {
        MailDal dal = new MailDal();

        public int insertmailServices(Mail mail)
        {
            return dal.insertmailService(mail);
        }
        public List<Mail> getAllmailtList()
        {
            return dal.getAllmailtList();
        }
        public List<Mail> getMailbyId(string edit)
        {
            return dal.getMailbyId(edit);
        }

        public int updategroup(Mail mail)
        {
            return dal.updategroup(mail);
        }

        public int sofrDelete(string delete)
        {
            return dal.softDelete(delete);
        }

    }
}