//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FormOverlapDetection.MergedModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRIZ
    {
        public int ID { get; set; }
        public int id_from_base { get; set; }
        public int source_db_id { get; set; }
        public string FAM { get; set; }
        public string IM { get; set; }
        public string OTCH { get; set; }
        public Nullable<System.DateTime> D_ROD { get; set; }
        public string RVK { get; set; }
        public Nullable<int> kom_id { get; set; }
        public Nullable<int> FL_UB { get; set; }
        public string SPEC { get; set; }
        public string BRAK { get; set; }
        public string SUD { get; set; }
        public string OBRAZOV { get; set; }
        public string PROF_P { get; set; }
        public string NPU { get; set; }
        public string REZH_KOM { get; set; }
        public string GODN { get; set; }
        public Nullable<int> P_PREDN { get; set; }
        public string TDT { get; set; }
        public Nullable<int> F_DOP { get; set; }
        public string N_DOP { get; set; }
        public Nullable<System.DateTime> D_DOP { get; set; }
        public Nullable<System.DateTime> D_PRIB { get; set; }
        public Nullable<int> FL_UV { get; set; }
        public Nullable<System.DateTime> D_U_UVOL { get; set; }
        public Nullable<System.DateTime> D_P_UVOL { get; set; }
        public Nullable<int> FL_SOCH { get; set; }
        public Nullable<System.DateTime> D_U_SOCH { get; set; }
        public string HIST { get; set; }
        public Nullable<int> ROST { get; set; }
        public Nullable<int> MASSA { get; set; }
        public string STAT { get; set; }
        public string S_V_BIL { get; set; }
        public string N_V_BIL { get; set; }
        public string PRIM { get; set; }
        public string PR_UBIT { get; set; }
        public string PRIM_UBIT { get; set; }
        public string ZREN { get; set; }
        public string R_G_U { get; set; }
        public string R_O_G { get; set; }
        public string R_OB { get; set; }
        public string H { get; set; }
        public Nullable<int> POSTO { get; set; }
        public string LN_SER { get; set; }
        public string LN_NUM { get; set; }
        public string S_PASPORT { get; set; }
        public string N_PASPORT { get; set; }
        public Nullable<System.DateTime> D_PASPORT { get; set; }
        public Nullable<int> IMEET_RAZR { get; set; }
        public Nullable<int> IMEET_REB { get; set; }
        public Nullable<int> ODIN_ROD { get; set; }
        public Nullable<int> BEZ_ROD { get; set; }
        public string DO_PRIZ { get; set; }
        public string NA_UCHETE { get; set; }
        public Nullable<short> NAVY { get; set; }
        public string S_VA { get; set; }
        public string N_VA { get; set; }
        public string M_ROD { get; set; }
        public string KEM_VIDAN { get; set; }
        public Nullable<int> TSP { get; set; }
    
        public virtual kom kom { get; set; }
        public virtual sourceDatabase sourceDatabase { get; set; }
    }
}
