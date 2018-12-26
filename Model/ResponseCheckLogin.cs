using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Data;
using Newtonsoft.Json;

namespace Model
{
    [Serializable]
    public class ResponseCheckLogin : ResponseBase
    {
        public CheckLoginData Data
        {
            get
            {
                CheckLoginData data = null;
                if (base.data != null && base.data.ToString() != string.Empty)
                {
                    data = JsonConvert.DeserializeObject<CheckLoginData>(base.data.ToString());
                }
                return data;
            }
        }
    }
}
