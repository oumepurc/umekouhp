using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace umekou.Models
{
    public class CardModel
    {

        //================================================================
        //データ取得
        //================================================================
        public List<CardContentData> getData(SearchCondition_Card condition, ref bool result, ref string resErrMsg)
        {
            List<CardContentData> list = new List<CardContentData>();


            using (umekoudbDataContext dc = new umekoudbDataContext())
            {
                try
                {
                    var items = from o in dc.card_t
                                where
                                    (condition.id == null || o.id == condition.id)

                                orderby o.reg_date descending
                                select o;

                    if (items == null)
                    {
                        return list;
                    }

                    foreach (var item in items)
                    {
                        CardContentData data = new CardContentData();
                        data.setData(item);
                        list.Add(data);
                    }




                }
                catch (Exception ex)
                {
                    result = false;
                    resErrMsg = ex.ToString();
                }

            }

            return list;

        }


        //================================================================
        //登録   今日のひとこと記事　　
        //================================================================
        public bool add(CardContentData addData, ref int? insertedID, ref string resErrMsg)
        {
            DateTime regDate = DateTime.Now;
            bool result = false;
            try
            {
                using (umekoudbDataContext dc = new umekoudbDataContext())
                {
                    using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                    {
                        addData.raw.reg_date = regDate;
                        dc.GetTable<card_t>().InsertOnSubmit(addData.raw);
                        dc.SubmitChanges();
                        insertedID = addData.raw.id;//主キーをセット
                        ts.Complete();
                    }
                }
                result = true;
            }
            catch (Exception e)
            {
                resErrMsg = e.Message;
                result = false;
            }
            return result;

        }

        //================================================================
        //データ削除処理　　
        //================================================================
        public bool remove(int id, ref string resErrMsg)
        {
            DateTime regDate = DateTime.Now;
            bool result = false;
            try
            {
                using (umekoudbDataContext dc = new umekoudbDataContext())
                {
                    using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                    {
                        var deleteItems = (from o in dc.GetTable<card_t>() where o.id == id select o);
                        if (deleteItems.Count() == 0)
                        {
                            resErrMsg = "削除しようとしたデータはすでに存在しませんでした";
                            return false;
                        }
                        card_t deleteItem = deleteItems.Single();

                        //データ削除
                        dc.GetTable<card_t>().DeleteOnSubmit(deleteItem);
                        dc.SubmitChanges();
                        ts.Complete();
                    }
                }

                result = true;
            }
            catch (Exception e)
            {
                resErrMsg = e.Message;
                result = false;
            }
            return result;
        }


        //================================================================
        //更新　　
        //================================================================
        public bool update(CardContentData pData, ref string resErrMsg)
        {
            DateTime upDate = DateTime.Now;
            bool result = false;
            try
            {
                using (umekoudbDataContext dc = new umekoudbDataContext())
                {
                    using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                    {
                        var updateItems = (from o in dc.GetTable<card_t>() where o.id == pData.raw.id select o);

                        if (updateItems == null)
                        {
                            resErrMsg = "更新するデータがすでに存在しませんでした";
                            result = false;
                            return result;
                        }


                        //更新データを記入
                        var upItem = updateItems.Single();
                        upItem.up_date = upDate;
                        upItem.up_user = pData.raw.up_user;
                        upItem.width = pData.raw.width;
                        upItem.height = pData.raw.height;
                        upItem.bg_color = pData.raw.bg_color;
                        upItem.border_color = pData.raw.border_color;
                        upItem.contents = pData.raw.contents;

                        //データ更新実行
                        dc.SubmitChanges();
                        ts.Complete();
                    }
                }
                result = true;
            }
            catch (Exception e)
            {
                resErrMsg = e.Message;
                result = false;
            }



            return result;

        }
    }
}