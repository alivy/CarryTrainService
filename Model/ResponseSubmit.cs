using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Data;
using Newtonsoft.Json;

namespace Model
{
    [Serializable]
    public class ResponseSubmit : ResponseBase
    {
        public SubmitData Data
        {
            get
            {
                SubmitData data = null;
                if (base.data != null && base.data.ToString() != string.Empty)
                {
                    data = JsonConvert.DeserializeObject<SubmitData>(base.data.ToString());
                }
                return data;
            }
        }
    }
}
