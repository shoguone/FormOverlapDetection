using FormOverlapDetection.CurrentModel;
using FormOverlapDetection.MergedModel;
using FormOverlapDetection.Templates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FormOverlapDetection
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> v_vs = new List<string>();
        private List<PrizConverter> result = new List<PrizConverter>();
		
        public MainWindow()
        {
            InitializeComponent();

            v_vs.Add("ВВ");
            v_vs.Add("ВВ МВД");
            v_vs.Add("ПП");
            v_vs.Add("МЧС");
            v_vs.Add("СССИ");

            //CurrentSearch();
            AbsoluteTokensSearch();
            AbsoluteMilitaryCardsSearch();
            AbsolutePassportsSearch();

            FillDrafts();
            
            ResultsDataGrid.ItemsSource = result;
        }

        void CurrentSearch()
        {
            //List<CurrentModel.PRIZ> curP = new List<CurrentModel.PRIZ>();
            List<CurrentModel.PRIZ> curP;
            using (var ctx = new CurrentModelEntities())
            {
                curP = ctx.PRIZ
                    .Where(p => p.N_KOM != "15")
                    .Join(ctx.kom, p => p.N_KOM, k => k.N_KOM, (p, k) => new { P = p, K = k })
                    .Where(e => !v_vs.Contains(e.K.V_VS))
                    .Select(e => e.P)
                    .ToList();
            }

            List<MergedModel.PRIZ> mrgdP = new List<MergedModel.PRIZ>();
            using (var ctx = new MergedModelEntities())
            {
                foreach(var p in curP)
                {
                    var entity = ctx.PRIZ.FirstOrDefault(e => e.LN_SER == p.LN_SER && e.LN_NUM == p.LN_NUM
                        && e.kom.N_KOM != "15" && !v_vs.Contains(e.kom.V_VS));
                    if (entity != default(MergedModel.PRIZ))
                    {
                        mrgdP.Add(entity);
                    }
                }
            }

        }

        void AbsoluteTokensSearch()
        {
            List<PrizConverter> mergedInMemoryList = new List<PrizConverter>();

            using (var ctx = new CurrentModelEntities())
            {

                var entities = ctx.PRIZ
                    .Join(ctx.kom, p => p.N_KOM, k => k.N_KOM, (p, k) => new { P = p, K = k })
                    .Where(e => e.K.N_KOM != "15" && e.K.V_VS != null && !v_vs.Contains(e.K.V_VS))
                    .Select(e => new { ID = e.P.ID, Season = "Current", LN = e.P.LN_SER + e.P.LN_NUM })
                    .ToList();

                mergedInMemoryList.AddRange(entities
                    .Select(e => new PrizConverter()
                    {
                        ID = e.ID,
                        Season = e.Season,
                        LN = e.LN
                    })
                );
            }


            using (var ctx = new MergedModelEntities())
            {
                var entities = ctx.PRIZ
                    .Where(p => p.kom.N_KOM != "15" && p.kom.V_VS != null && !v_vs.Contains(p.kom.V_VS))
                    .Select(e => new { ID = e.ID, Season = e.sourceDatabase.dbName, LN = e.LN_SER + e.LN_NUM })
                    .ToList();

                mergedInMemoryList.AddRange(entities
                    .Select(e => new PrizConverter()
                    {
                        ID = e.ID,
                        Season = e.Season,
                        LN = e.LN
                    })
                );
            }


            result.AddRange(mergedInMemoryList
                .GroupBy(p => p.LN)
                .Where(g => !string.IsNullOrEmpty(g.Key) && g.Count() > 1 && g.Any(e => e.Season == "Current"))
                .SelectMany(e => e));
                //.ToList();

        }

        void AbsoluteMilitaryCardsSearch()
        {
            List<PrizConverter> mergedInMemoryList = new List<PrizConverter>();

            using (var ctx = new CurrentModelEntities())
            {

                var entities = ctx.PRIZ
                    .Where(e => e.N_KOM != "15")
                    .Select(e => new { ID = e.ID, Season = "Current", VB = e.S_V_BIL + e.N_V_BIL })
                    .ToList();

                mergedInMemoryList.AddRange(entities
                    .Select(e => new PrizConverter()
                    {
                        ID = e.ID,
                        Season = e.Season,
                        VB = e.VB
                    })
                );
            }


            using (var ctx = new MergedModelEntities())
            {
                var entities = ctx.PRIZ
                    .Where(p => p.kom.N_KOM != "15")
                    .Select(e => new { ID = e.ID, Season = e.sourceDatabase.dbName, VB = e.S_V_BIL + e.N_V_BIL })
                    .ToList();

                mergedInMemoryList.AddRange(entities
                    .Select(e => new PrizConverter()
                    {
                        ID = e.ID,
                        Season = e.Season,
                        LN = e.VB
                    })
                );
            }


            result.AddRange(mergedInMemoryList
                .GroupBy(p => p.VB)
                .Where(g => !string.IsNullOrEmpty(g.Key) && g.Count() > 1 && g.Any(e => e.Season == "Current"))
                //.ToList()
                .SelectMany(e => e));

        }

        void AbsolutePassportsSearch()
        {
            List<PrizConverter> mergedInMemoryList = new List<PrizConverter>();

            using (var ctx = new CurrentModelEntities())
            {

                var entities = ctx.PRIZ
                    .Where(e => e.N_KOM != "15")
                    .Select(e => new { ID = e.ID, Season = "Current", PP = e.S_PASPORT + e.N_PASPORT })
                    .ToList();

                mergedInMemoryList.AddRange(entities
                    .Select(e => new PrizConverter()
                    {
                        ID = e.ID,
                        Season = e.Season,
                        PP = e.PP
                    })
                );
            }


            using (var ctx = new MergedModelEntities())
            {
                var entities = ctx.PRIZ
                    .Where(p => p.kom.N_KOM != "15")
                    .Select(e => new { ID = e.ID, Season = e.sourceDatabase.dbName, PP = e.S_PASPORT + e.N_PASPORT })
                    .ToList();

                mergedInMemoryList.AddRange(entities
                    .Select(e => new PrizConverter()
                    {
                        ID = e.ID,
                        Season = e.Season,
                        PP = e.PP
                    })
                );
            }


            result.AddRange(mergedInMemoryList
                .GroupBy(p => p.PP)
                .Where(g => !string.IsNullOrEmpty(g.Key) && g.Count() > 1 && g.Any(e => e.Season == "Current"))
                //.ToList()
                .SelectMany(e => e));

        }

        void FillDrafts()
        {
            PrizEqualityComparer pec = new PrizEqualityComparer();
            result = result
                .Distinct(pec)
                .ToList();

            foreach (PrizConverter res in result)
            {
                if (res.Season == "Current")
                {
                    using (var c = new CurrentModelEntities())
                    {
                        var e = c.PRIZ.First(p => p.ID == res.ID);
                        res.D_PASPORT = e.D_PASPORT;
                        res.D_PRIB = e.D_PRIB;
                        res.D_ROD = e.D_ROD;
                        res.FAM = e.FAM;
                        res.FL_UB = e.FL_UB;
                        res.IM = e.IM;
                        res.LN_NUM = e.LN_NUM;
                        res.LN_SER = e.LN_SER;
                        res.N_KOM = e.N_KOM;
                        res.N_PASPORT = e.N_PASPORT;
                        res.N_V_BIL = e.N_V_BIL;
                        res.OTCH = e.OTCH;
                        res.RVK = e.RVK;
                        res.S_PASPORT = e.S_PASPORT;
                        res.S_V_BIL = e.S_V_BIL;
                    }
                }
                else
                {
                    using (var c = new MergedModelEntities())
                    {
                        var e = c.PRIZ.First(p => p.ID == res.ID);
                        res.D_PASPORT = e.D_PASPORT;
                        res.D_PRIB = e.D_PRIB;
                        res.D_ROD = e.D_ROD;
                        res.FAM = e.FAM;
                        res.FL_UB = e.FL_UB;
                        res.IM = e.IM;
                        res.LN_NUM = e.LN_NUM;
                        res.LN_SER = e.LN_SER;
                        res.N_KOM = e.kom.N_KOM;
                        res.N_PASPORT = e.N_PASPORT;
                        res.N_V_BIL = e.N_V_BIL;
                        res.OTCH = e.OTCH;
                        res.RVK = e.RVK;
                        res.S_PASPORT = e.S_PASPORT;
                        res.S_V_BIL = e.S_V_BIL;
                    }
                }
            }

            //Process.Start();
        }

    }

    public class PrizEqualityComparer : IEqualityComparer<PrizConverter>
    {

        public bool Equals(PrizConverter p1, PrizConverter p2)
        {
            if (p1.ID == p2.ID
                & p1.Season == p2.Season)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public int GetHashCode(PrizConverter p)
        {
            string hCode = p.Season + p.ID;
            return hCode.GetHashCode();
        }

    }
}

