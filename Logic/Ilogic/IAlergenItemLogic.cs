﻿using Entities.Entities;
using Resources.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Ilogic
{
    public interface IAlergenItemLogic
    {

        List<AlergenItem> GetAlergens();
        int InsertAlergen(AlergenRequest alergenRequest);

        void DeleteAlergen(int id);
    }
}