using FormOverlapDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormOverlapDetection.Templates
{
    public class PrizConverter
    {
        public int ID { get; set; }

        public string FAM { get; set; }
        public string IM { get; set; }
        public string OTCH { get; set; }
        public DateTime? D_ROD { get; set; }
        public string RVK { get; set; }
        public string N_KOM { get; set; }
        public int? FL_UB { get; set; }
        public DateTime? D_PRIB { get; set; }
        public string S_V_BIL { get; set; }
        public string N_V_BIL { get; set; }
        public string LN_SER { get; set; }
        public string LN_NUM { get; set; }
        public string S_PASPORT { get; set; }
        public string N_PASPORT { get; set; }
        public DateTime? D_PASPORT { get; set; }

        public string Season { get; set; }
        
        //public string LN { get; set; }
        public string LN;
        public string VB;
        public string PP;

        public PrizConverter()
        {

        }

        public PrizConverter(CurrentModel.PRIZ cp)
        {
            ID = cp.ID;
            FAM = cp.FAM;
            IM = cp.IM;
            OTCH = cp.OTCH;
            D_ROD = cp.D_ROD;
            RVK = cp.RVK;
            N_KOM = cp.N_KOM;
            FL_UB = cp.FL_UB;
            D_PRIB = cp.D_PRIB;

            S_V_BIL = cp.S_V_BIL;
            N_V_BIL = cp.N_V_BIL;

            LN_SER = cp.LN_SER;
            LN_NUM = cp.LN_NUM;

            S_PASPORT = cp.S_PASPORT;
            N_PASPORT = cp.N_PASPORT;
            D_PASPORT = cp.D_PASPORT;
        }

        public PrizConverter(MergedModel.PRIZ mp)
        {
            ID = mp.ID;
            FAM = mp.FAM;
            IM = mp.IM;
            OTCH = mp.OTCH;
            D_ROD = mp.D_ROD;
            RVK = mp.RVK;
            N_KOM = mp.kom.N_KOM;
            FL_UB = mp.FL_UB;
            D_PRIB = mp.D_PRIB;

            S_V_BIL = mp.S_V_BIL;
            N_V_BIL = mp.N_V_BIL;

            LN_SER = mp.LN_SER;
            LN_NUM = mp.LN_NUM;

            S_PASPORT = mp.S_PASPORT;
            N_PASPORT = mp.N_PASPORT;
            D_PASPORT = mp.D_PASPORT;
        }

        public static CurrentModel.PRIZ Convert(MergedModel.PRIZ mp)
        {
            CurrentModel.PRIZ cp = new CurrentModel.PRIZ();

            cp.ID = mp.ID;
            cp.FAM = mp.FAM;
            cp.IM = mp.IM;
            cp.OTCH = mp.OTCH;
            cp.D_ROD = mp.D_ROD;
            cp.RVK = mp.RVK;
            cp.N_KOM = mp.kom.N_KOM;
            cp.FL_UB = mp.FL_UB;
            cp.SPEC = mp.SPEC;
            cp.BRAK = mp.BRAK;
            cp.SUD = mp.SUD;
            cp.OBRAZOV = mp.OBRAZOV;
            cp.PROF_P = mp.PROF_P;
            cp.NPU = mp.NPU;
            cp.REZH_KOM = mp.REZH_KOM;
            cp.GODN = mp.GODN;
            cp.P_PREDN = mp.P_PREDN;
            cp.TDT = mp.TDT;
            cp.F_DOP = mp.F_DOP;
            cp.N_DOP = mp.N_DOP;
            cp.D_DOP = mp.D_DOP;
            cp.D_PRIB = mp.D_PRIB;
            cp.FL_UV = mp.FL_UV;
            cp.D_U_UVOL = mp.D_U_UVOL;
            cp.D_P_UVOL = mp.D_P_UVOL;
            cp.FL_SOCH = mp.FL_SOCH;
            cp.D_U_SOCH = mp.D_U_SOCH;
            cp.HIST = mp.HIST;
            cp.ROST = mp.ROST;
            cp.MASSA = mp.MASSA;
            cp.STAT = mp.STAT;
            cp.S_V_BIL = mp.S_V_BIL;
            cp.N_V_BIL = mp.N_V_BIL;
            cp.PRIM = mp.PRIM;
            cp.PR_UBIT = mp.PR_UBIT;
            cp.PRIM_UBIT = mp.PRIM_UBIT;
            cp.ZREN = mp.ZREN;
            cp.R_G_U = mp.R_G_U;
            cp.R_O_G = mp.R_O_G;
            cp.R_OB = mp.R_OB;
            cp.H = mp.H;
            cp.POSTO = mp.POSTO;
            cp.LN_SER = mp.LN_SER;
            cp.LN_NUM = mp.LN_NUM;
            cp.S_PASPORT = mp.S_PASPORT;
            cp.N_PASPORT = mp.N_PASPORT;
            cp.D_PASPORT = mp.D_PASPORT;
            cp.IMEET_RAZR = mp.IMEET_RAZR;
            cp.IMEET_REB = mp.IMEET_REB;
            cp.ODIN_ROD = mp.ODIN_ROD;
            cp.BEZ_ROD = mp.BEZ_ROD;
            cp.DO_PRIZ = mp.DO_PRIZ;
            cp.NA_UCHETE = mp.NA_UCHETE;
            cp.NAVY = mp.NAVY;
            cp.S_VA = mp.S_VA;
            cp.N_VA = mp.N_VA;
            cp.M_ROD = mp.M_ROD;
            cp.KEM_VIDAN = mp.KEM_VIDAN;
            cp.TSP = mp.TSP;

            return cp;
        }
    }
}
