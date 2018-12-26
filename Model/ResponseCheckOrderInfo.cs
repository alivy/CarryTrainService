using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Model.Data;

namespace Model
{
    [Serializable]
    public class ResponseCheckOrderInfo : ResponseBase
    {
        public CheckOrderInfoData Data
        {
            get
            {
                CheckOrderInfoData data = null;
                if (base.data != null && base.data.ToString() != string.Empty)
                {
                    data = JsonConvert.DeserializeObject<CheckOrderInfoData>(base.data.ToString());
                }
                return data;
            }
        }
    }
}
