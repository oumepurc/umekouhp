using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace umekou.Models
{
    public class Repositories
    {
    }



    //======================================
    //カードデータ
    //======================================
    public class CardContentData
    {

        public string edit_data
        {
            get { return this.raw.contents; }
            set { this.raw.contents = value; }
        }

       


        public card_t raw { get; set; }

        public CardContentData()
        {
            this.raw = new card_t();
        }

        public void setData(card_t pRaw)
        {
            this.raw = pRaw;
        }
    }

    //======================================
    //カード検索条件クラス
    //======================================
    public class SearchCondition_Card
    {
        public int? id { get; set; }

       
    }


    public class JsonResultData
    {
        public string errMsg;
        public bool result;
    }



}