using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace RationCard.Model
{
    public static class MasterDataHelper
    {
        public static CategoryWiseSearchResult SearchCard(string searchBy, string searchText, string searchCatId, bool fetchOnlyRecentData = false)
        {
            int convertedNum = 0;
            var result = new CategoryWiseSearchResult();
            result.CardSearchResult = new List<RationCardDetail>();
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();               

                sqlParams.Add(new SqlParameter { ParameterName = "@userId", SqlDbType = SqlDbType.VarChar, Value = User.LoginId });
                sqlParams.Add(new SqlParameter { ParameterName = "@searchBy", SqlDbType = SqlDbType.VarChar, Value = searchBy });
                sqlParams.Add(new SqlParameter { ParameterName = "@searchText", SqlDbType = SqlDbType.VarChar, Value = searchText });
                sqlParams.Add(new SqlParameter { ParameterName = "@searchCatId", SqlDbType = SqlDbType.VarChar, Value = (string.IsNullOrEmpty(searchCatId) ? DBNull.Value.ToString() : searchCatId) });
                sqlParams.Add(new SqlParameter
                {
                    ParameterName = "@dtFrom",
                    SqlDbType = SqlDbType.VarChar,
                    Value = fetchOnlyRecentData
                                ? MasterData.DataFetchTime.ToString("MM-dd-yyyy HH:mm:ss")
                                : DateTime.Parse("01-01-1900").ToString("MM-dd-yyyy HH:mm:ss")
                });
                sqlParams.Add(new SqlParameter { ParameterName = "@dtTo", SqlDbType = SqlDbType.VarChar, Value = DateTime.Parse("04-04-2018").ToString("MM-dd-yyyy HH:mm:ss") });

                DataSet ds = ConnectionManager.Exec("Sp_RationCard_Search", sqlParams);

                if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    int count = 1;
                    result.CardCountOfCategory = int.TryParse(ds.Tables[1].Rows[0]["RECORD_COUNT"].ToString(), out convertedNum) ? convertedNum : 0;
                    result.CategoryOfCard = MasterData.Categories.FirstOrDefault(i => i.Cat_Id == searchCatId);
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        result.CardSearchResult.Add(new RationCardDetail
                        {
                            SlNo = count,
                            Number = r["RATIONCARD_NO"].ToString(),
                            Adhar_No = r["Adhar_No"].ToString(),
                            Mobile_No = r["Mobile_No"].ToString(),
                            Hof_Name = r["HOF_NAME"].ToString(),
                            Name = r["Name"].ToString(),
                            Age = r["Age"].ToString(),
                            Address = r["Address"].ToString(),
                            CardStatus = (r["STATUS"].ToString() == "True") ? "Active" : "",
                            ActiveCard = r["STATUS"].ToString() == "True",
                            Card_Created_Date = r["Created_Date"].ToString(),
                            Cat_Desc = r["Cat_Desc"].ToString(),
                            Customer_Id = r["Customer_Id"].ToString(),
                            Hof_Flag = r["Hof_Flag"].ToString(),
                            Hof_Id = r["Hof_Id"].ToString(),
                            RationCard_Id = r["RationCard_Id"].ToString(),
                            Cat_Id = r["Cat_Id"].ToString(),
                            Card_Category_Id = r["Cat_Id"].ToString(),
                            Remarks = r["Remarks"].ToString(),
                            Relation_With_Hof = r["Relation_With_Hof"].ToString(),
                            Gaurdian_Relation = r["Gaurdian_Relation"].ToString(),
                            Gaurdian_Name = r["Gaurdian_Name"].ToString()
                            //FamilyCount = r["TOTAL_CARD_COUNT"].ToString(),
                            //CardCount = r["ACTIVE_CARD_COUNT"].ToString()
                        });
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return result;
        }

        public static RationCardDetail FetchFamilyCount(string custId)
        {
            int convertedNum = 0;
            RationCardDetail card = new RationCardDetail();
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "@userId", SqlDbType = SqlDbType.VarChar, Value = User.LoginId });
                sqlParams.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.VarChar, Value = custId });

                DataSet ds = ConnectionManager.Exec("Sp_GetCardCount", sqlParams);

                if ((ds != null) && (ds.Tables.Count > 1))
                {
                    card.FamilyCount = (( //TOTAL_CARD_COUNT
                        (ds.Tables[0].Rows.Count > 0) && Int32.TryParse(ds.Tables[0].Rows[0][0].ToString(), out convertedNum)) 
                        ? convertedNum : 0).ToString();
                    card.CardCount = (( //Active_CARD_COUNT
                        (ds.Tables[1].Rows.Count > 0) && Int32.TryParse(ds.Tables[1].Rows[0][0].ToString(), out convertedNum))
                        ? convertedNum : 0).ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return card;
        }
    }
}
