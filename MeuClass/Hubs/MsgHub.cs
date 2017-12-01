using MeuClass.Admin;
using Microsoft.AspNet.SignalR;

namespace MeuClass.Hubs
{
    public class MessagaService : BaseController
    {
        //public static void Connect(string _connectionID, string _username)
        //{
        //    using (var db = new DAL.MyDatabase())
        //    {
        //        if (db.OnlineUser.Where(a => a.ConnetionID == _connectionID).Count() < 1)
        //        {
        //            var _user = db.Users.Where(a => a.Username == _username).FirstOrDefault();

        //            if (_user != null)
        //            {
        //                var user = new OnlineUser()
        //                {
        //                    ConnetionID = _connectionID,
        //                    UserID = _user.ID,
        //                    Username = _user.Username

        //                };
        //                db.OnlineUser.Add(user);
        //                db.SaveChanges();

        //            }

        //        }

        //    }
        //}

        //public static void Disconnect(string _connectionID)
        //{
        //    using (var db = new DAL.MyDatabase())
        //    {

        //        var _user = db.OnlineUser.Where(a => a.ConnetionID == _connectionID).FirstOrDefault();

        //        if (_user != null)
        //        {
        //            db.OnlineUser.Remove(_user);
        //            db.SaveChanges();

        //        }
        //    }


        //}

        //public static List<OnlineUser> GetList()
        //{
        //    using (var db = new DAL.MyDatabase())
        //    {
        //        return db.OnlineUser.ToList();
        //    }
        //}
    }


    public class MsgHub : Hub
    {

        //private List<OnlineUser> Users {
        //    get
        //    {
        //      return MessagaService.GetList();
        //        // sadece arkadaşları görünmesi için kısıtyazılacak
        //    }
        //    set
        //    {
        //        Users = value;
        //    }
        //}


        //public Task connect(string _username)
        //{

        //    var conId = Context.ConnectionId;

        //    MessagaService.Connect(conId, _username);

        //    Clients.All.updateOnlineUsers(Users);

        //    return base.OnConnected();
        //}


        //public override Task OnDisconnected(bool stopCalled)
        //{
        //    var conId = Context.ConnectionId;

        //    MessagaService.Disconnect(conId);
        //    Clients.All.updateOnlineUsers(Users);

        //    return base.OnDisconnected(stopCalled);
        //}


    }
}