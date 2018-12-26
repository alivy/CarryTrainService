using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Data;
using Newtonsoft.Json;

namespace Model
{
    /// <summary>
    /// 旅客包
    /// </summary>
    [Serializable]
    public class ResponsePassenger : ResponseBase
    {
        public PassengerData Data
        {
            get
            {
                PassengerData data = null;
                if (base.data != null && base.data.ToString() != string.Empty)
                {
                    data = JsonConvert.DeserializeObject<PassengerData>(base.data.ToString());
                }
                return data;
            }
        }
    }
}
