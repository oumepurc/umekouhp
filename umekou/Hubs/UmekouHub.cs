using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

using umekou.Models;
namespace umekou.Hubs
{
    [HubName("umekouHub")]
    public class UmekouHub : Hub
    {
        public void Send(CardContentData data)
        {
            CardModel model = new CardModel();
            int? insertedID = null;
            string resMsg = "";
            bool result = false;

            result = model.add(data, ref insertedID, ref resMsg);
            if (result == false)
            {

            }
            Clients.All.addNewMessageToPage(data);
        }

        public void Add(CardContentData data)
        {
            CardModel model = new CardModel();
            int? insertedID = null;
            string resMsg = "";
            bool result = false;

            result = model.add(data, ref insertedID, ref resMsg);
            if (result == false)
            {

            }

            //TODO 処理の結果、および更新されたデータをクライアントに伝える
            Clients.All.addNewMessageToPage(data);
        }


        public void Update(CardContentData data)
        {

            CardModel model = new CardModel();
            int? insertedID = null;
            string resMsg = "";
            bool result = false;

            //result = model.add_HitokotoData(data, ref insertedID, ref resMsg);
            //if (result == false)
            //{

            //}

            //TODO 処理の結果、および更新されたデータをクライアントに伝える
            //Clients.All.addNewMessageToPage(data);
        }

        public void RemoveData(int id)
        {
            Clients.All.removeDataMessageToPage(id);
        }


    }
}