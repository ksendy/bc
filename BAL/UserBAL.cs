using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BAL
{
    public class UserBAL
    {
        public bool CekLogin(string username, string pwd)
        {
            UserDAL dal = new UserDAL();         
            return dal.UserAuth(username, pwd);
        }

        public int getLevel(string username)
        {
            UserDAL dal = new UserDAL();
            MsCustomer c = new MsCustomer();
            c = dal.GetUserByUsername(username);
            return c.lvl;
        }

        public MsUserBAL getUserByUsername(string username)
        {
            UserDAL dal = new UserDAL();
            MsUserBAL bal = new MsUserBAL();
            MsCustomer c = new MsCustomer();
            c = dal.GetUserByUsername(username);
            return bal.ConvertToMsMsUserBAL(c);

        }

        public bool AddUser(MsUserBAL b)
        {
            UserDAL dal = new UserDAL();    
            //cek user double
            if(dal.GetUserByUsername(b.username) == null)
            {
                //input user id
                int newId = dal.GetLastId() + 1;
                b.idCustomer = newId.ToString();
                return dal.AddUser(b.ConvertToMsMsCustomer(b));
            }
            return false;
            
        }

        public bool DeleteUser(string id)
        {
            UserDAL dal = new UserDAL();
            return dal.DeleteUser(id);
        }

        public bool UpdateUser(MsUserBAL baru)
        {
            MsCustomer cust = new MsCustomer();
            UserDAL dal = new UserDAL();
            cust = baru.ConvertToMsMsCustomer(baru);
            return dal.UpdateUser(cust);
        }

        public string GetLastId()
        {
            UserDAL dal = new UserDAL();
            return dal.GetLastId().ToString();
        }

        public List<MsUserBAL> GetUserList()
        {
            UserDAL dal = new UserDAL();
            List<MsCustomer> mc = new List<MsCustomer>();
            List<MsUserBAL> mu = new List<MsUserBAL>();
            mc = dal.GetUserList();
            foreach (MsCustomer cus in mc)
            {
                MsUserBAL ub = new MsUserBAL();
                ub = ub.ConvertToMsMsUserBAL(cus);
                mu.Add(ub);
            }
            return mu;
        }

        public MsUserBAL GetUserById(string id)
        {
            UserDAL dal = new UserDAL();
            MsUserBAL mu = new MsUserBAL();
            mu = mu.ConvertToMsMsUserBAL(dal.GetUserById(id));
            return mu;

        }



    }
}
