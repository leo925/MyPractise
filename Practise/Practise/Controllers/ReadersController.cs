﻿using Models;
using Practise.Db;
using Practise.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practise.Controllers
{
    [LogFilterAttribute]
    public class ReadersController : Controller
    {

        MyPractiseDb _db = new Db.MyPractiseDb();
        // GET: Readers
        public ActionResult Index()
        {
            //string[] leftOverArray = allLeftOvers.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            //var length = leftOverArray.Length;
            //var intLeftOverArray = leftOverArray.ToList().Select<string, int>(str =>
            //{
            //    return int.Parse(str);
            //}).ToList();

            //var max = intLeftOverArray.Max();
            //var sections = Math.Ceiling((double)max / 100);
            //Dictionary<int, int> SectionCountDic = new Dictionary<int, int>();
            //for (int i = 0; i < sections; i++)
            //{

            //}

            //foreach (var leftOver in intLeftOverArray)
            //{
            //    int section = leftOver / 30 + 1;
            //    if (!SectionCountDic.Keys.Contains(section))
            //    {
            //        SectionCountDic.Add(section, 1);
            //    }
            //    else
            //    {
            //        var newValue = SectionCountDic[section] + 1;
            //        SectionCountDic[section] = newValue;
            //    }
            //}

            //var orderDic = SectionCountDic.OrderByDescending(d => d.Value).ToList();


            //ssList<ReaderModel> readers = DummyReaders;
            var readers = _db.Readers.ToList();
            return View(readers);
        }

        public ActionResult FirstReader()
        {
            var first = DummyReaders.FirstOrDefault();
            return PartialView("_Reader", first);
        }

        // GET: Readers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Readers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Readers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Readers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Readers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Readers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Readers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public static List<ReaderModel> DummyReaders = GenerateReaders();
        private static List<ReaderModel> GenerateReaders()
        {
            List<ReaderModel> readers = new List<ReaderModel>();
            for (int i = 0; i < 15; i++)
            {

                ReaderModel reader = new ReaderModel()
                {
                    Name = "reader " + i.ToString(),
                    IP = "10,1,10," + i.ToString(),
                    Port = i,
                    Id = i
                };
                readers.Add(reader);
            }
            return readers;
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }


        private string allLeftOvers = @"
1247,552,318,25,443,1187,610,
380,215,1340,2514,155,404,
872,791,299,775,834,
658,726,1922,110,48,1968,
343,3435,201,
135,1709,
1174,1482,86,518,
634,355,878,261,631,733,
3378,952,625,
1283,863,1010,2297,
459,340,873,2553,
534,758,549,96,574,
563,4,1088,
1103,248,945,1584,977,
48,1009,408,361,409,102,6,78,558,1240,214,
1379,30,19,1117,888,532,
178,2593,269,145,261,
351,242,691,99,2813,574,414,
1348,1253,324,786,277,895,
1621,59,2386,102,1064,
794,230,187,2242,372,77,855,376,345,
149,550,1255,198,1041,676,825,
2657,290,1183,
2316,1958,454,276,
276,611,180,75,1920,400,1460,231,294,
890,4207,18,
1391,2843,
52,160,2463,1124,950,537,
428,690,945,215,1556,186,31,412,
578,752,587,1686,933,593,
1737,1154,359,1203,
271,92,292,13,2491,1702,
2179,
438,620,167,754,588,1758,292,230,482,
2158,
277,396,193,31,2092,142,66,695,2,525,411,491,
78,910,1321,2706,162,
3206,373,1057,
696,23,12,749,541,1101,737,
527,219,223,1666,263,990,731,
1657,162,1265,633,487,24,
951,507,1682,
1020,3871,
47,4868,
1281,472,594,896,1053,
2121,2290,129,
2164,791,47,268,946,887,
290,1485,253,488,62,2079,10,
312,4,197,1530,861,113,570,655,1201,
128,1123,1250,739,1611,310,
2264,11,150,446,605,1675,101,205,
350,3180,1459,24,80,
3372,
972,
404,1070,1639,
715,463,547,169,614,444,149,1783,133,
111,4068,
1133,1100,595,140,1623,
2078,2931,67,
995,165,31,372,1243,782,1210,
2070,1103,968,687,74,263,
70,35,946,258,901,1329,
245,266,920,490,782,369,785,314,879,
3209,1316,606,66,
1054,1214,1856,285,1042,
179,302,501,1098,954,644,85,936,717,
2105,1743,200,
1033,77,1201,2859,184,
297,419,2265,514,249,458,99,781,
3845,795,
756,837,81,1231,1380,80,
399,403,1168,667,1003,
92,440,213,8,823,101,3478,136,
345,724,1414,2399,
63,2204,1612,966,
334,596,373,66,168,227,1748,
4727,
39,2345,1561,763,26,372,
763,400,1356,874,762,1172,
652,1071,1011,1524,183,750,151,
1252,486,415,1565,560,
108,633,1279,
1700,1967,
1082,336,944,2465,110,498,
408,559,194,1122,275,938,1352,193,222,
235,569,525,532,1509,1336,
2881,300,1792,129,
822,865,1118,221,488,394,441,
797,153,1962,892,428,
140,802,120,2683,1104,462,
298,508,4120,
189,403,1173,784,600,583,120,
51,964,986,135,812,
311,2109,718,1886,62,
11,504,290,6,355,389,499,833,77,2148,
828,211,75,959,2396,659,
220,548,82,1175,130,489,561,427,
289,1772,211,1300,1278,
549,188,356,421,270,422,1527,857,433,
1463,50,334,350,321,2452,
738,819,1608,285,1916,
5072,
152,533,167,182,677,428,491,802,419,76,377,
150,1352,1293,1935,
661,62,1651,9,481,185,
374,4972,
3164,1706,
282,2305,
1149,1200,9,913,1973,
2256,874,15,727,606,395,
1949,421,1566,53,494,218,
329,2088,1864,215,303,189,
450,885,261,1104,724,1685,297,
122,720,378,892,806,450,
376,6,1676,612,401,452,29,
3,208,1655,15,605,666,738,
1471,862,1067,65,1044,949,
14,2958,35,1152,791,52,
161,141,2040,2092,295,736,
445,381,556,422,952,1410,711,471,
3401,173,853,454,
1936,103,86,367,544,1494,309,342,
6,1486,80,742,1330,466,
906,233,617,563,
2187,
191,2771,2430,
293,1173,32,695,1889,
2184,7,253,693,1160,619,298,
2589,2814,
341,40,1426,2365,1088,
2919,1049,1357,
818,1694,975,933,798,36,
209,589,1380,
2118,633,16,147,1358,4,
648,986,
1279,160,1151,252,935,1559,
66,
56,754,984,
1240,370,2573,179,210,379,
1800,
955,357,836,2241,
1059,1583,2269,
1662,1287,410,828,187,984,
2377,
227,662,14,273,1256,333,906,309,20,
1290,2225,49,1774,
215,893,
1786,769,2422,
508,1272,1181,83,900,1314,
504,469,1285,1155,673,624,
1763,1685,817,
160,5,1101,970,2054,1148,
157,674,94,186,2380,1174,114,
4031,1273,
448,2278,211,2519,
2539,676,95,628,282,287,48,
418,1648,1400,397,96,
771,676,22,115,384,991,2339,
886,464,2048,1049,905,78,
2355,36,
1397,591,2306,
1144,600,139,1380,97,
2802,283,1435,306,
531,1182,913,582,1165,
514,3106,31,697,375,
1790,78,823,367,1325,
2762,1424,
16,174,43,135,577,225,399,1534,422,529,
1248,2223,1100,67,
547,2920,1305,
301,200,3653,
401,214,2477,1688,618,
2318,858,208,512,758,
101,537,2630,325,678,43,384,38,108,
1129,2095,1408,
163,1224,1208,595,48,51,69,977,1138,
173,497,52,1094,2531,104,118,392,
611,536,2198,1568,
4381,316,336,
553,28,567,2762,
2387,519,692,262,
358,171,298,101,2409,146,243,792,431,23,297,
1339,516,2160,
778,156,864,990,
1036,1659,97,645,931,
733,108,1062,527,1648,86,
554,2249,63,131,252,
2628,296,923,48,1184,
933,438,492,494,40,723,1799,218,142,
262,1093,211,1087,233,437,791,62,369,
609,682,1117,1048,218,
1181,1946,386,1265,
1052,866,2659,
1862,1033,
617,3268,696,107,
1060,14,363,3564,
3613,1864,
1235,2444,373,938,
1012,988,825,12,800,1136,207,
679,707,1303,1325,79,530,108,
476,2,992,601,353,2825,
388,
103,2071,2082,369,
657,452,
926,428,176,626,29,7,762,856,159,123,192,
2623,1603,385,
2033,2145,508,
1196,1278,1254,627,208,
93,558,760,513,725,2031,105,
839,32,227,290,407,2988,42,35,41,
770,108,31,1647,
353,36,666,487,1219,1514,693,
1043,1176,69,292,568,1173,69,821,
308,85,1659,936,1022,
17,270,689,219,1066,3167,
569,136,960,895,58,240,833,617,105,
198,1648,2060,765,29,266,349,
2650,2736,
74,444,565,147,773,754,1552,595,355,
200,1478,704,209,410,1587,107,
959,2958,45,253,186,751,243,
456,1983,1166,261,1137,317,
702,585,336,337,439,862,1125,849,
1568,1202,81,1251,
433,2502,1081,1150,278,
330,805,202,162,
3325,2,746,1144,
1081,598,1266,256,1012,
77,2068,576,2071,
292,1074,165,1176,418,809,882,387,
832,1729,1154,1264,261,234,
139,1552,2326,
244,632,873,544,2621,
2646,109,642,433,
1352,396,1809,1154,668,
1046,219,79,1163,363,30,428,790,
2276,1142,108,22,663,
949,2813,1052,
120,3035,318,210,325,504,
1049,943,132,589,1083,688,18,
285,451,781,1212,267,1357,806,
230,402,5,370,1005,
875,20,293,621,89,471,169,1731,1064,
740,223,934,822,363,89,457,492,485,392,
2428,1276,1176,
1604,349,281,706,204,733,179,577,574,263,
3346,36,371,
266,671,54,2207,357,725,46,987,
390,1798,24,821,1220,1024,
1830,1033,773,739,814,
774,530,45,236,323,526,239,734,176,368,625,66,
1779,2152,60,
1105,31,770,397,1214,1573,
1546,106,50,774,71,
100,3134,152,1476,232,
755,660,802,2414,
148,1246,318,425,29,41,2143,
971,289,464,533,279,307,561,557,
320,975,807,613,538,
171,4095,965,
114,24,193,797,286,645,405,601,562,289,217,13,1207,
1091,1419,222,7,1123,894,251,
2744,92,1933,
155,294,554,325,312,1483,1474,459,276,88,60,
1835,305,2506,
1857,284,563,1200,810,198,
786,919,302,27,219,1388,405,
255,1621,138,470,1815,
1200,2365,246,
758,142,1012,235,148,360,1238,119,888,440,
167,684,1358,1531,1330,
112,3573,
174,1397,1006,84,753,388,842,
488,4893,
1072,20,1297,57,2002,442,2,255,255,
236,1603,53,348,1115,460,235,
2250,868,1,1193,309,798,
902,409,279,1950,678,781,140,271,
863,616,255,2440,48,
295,685,536,942,1144,1305,191,
3203,447,375,98,241,
612,82,262,501,1154,2040,
1154,272,1452,561,881,
224,1362,55,503,1030,2285,
1577,1803,1184,821,
9,88,482,3493,
3064,
690,195,491,43,2607,467,
278,798,436,163,159,110,140,
250,850,258,2510,382,706,
411,157,2045,955,964,320,
2211,1079,378,711,
497,68,309,580,80,548,294,195,1180,1038,416,
346,33,1210,2141,822,108,
275,197,1,917,1230,2305,
1645,1893,436,559,97,
507,1261,635,2013,202,175,
588,132,2145,317,651,109,436,204,
891,268,332,157,20,201,217,680,313,247,
132,2616,141,484,465,801,14,178,
131,72,175,4668,146,
124,2113,1283,366,220,
304,190,1021,2241,1514,112,
427,294,943,474,564,1765,756,
431,1579,1425,302,1406,
671,2267,2275,
109,96,2093,1552,325,982,297,
373,318,1413,411,364,1846,
500,2026,16,354,932,1080,
273,435,1368,551,834,223,1048,619,
728,430,243,430,134,1414,369,496,994,
54,308,1863,280,171,685,1226,371,53,
1403,1248,426,136,706,863,567,
360,304,760,1929,603,1269,5,
180,337,1306,860,131,332,1411,556,
90,235,831,461,705,1351,720,117,345,213,
305,791,1285,48,1090,
1564,1568,588,651,1050,
1773,1073,368,206,
2122,347,600,42,
142,885,1658,368,280,434,55,
435,63,1987,353,526,1574,272,
121,470,829,2129,479,806,
86,2661,2603,
80,613,1259,617,973,1742,
110,1707,713,266,1313,213,688,
1061,168,166,766,237,918,300,126,1243,6,382,
225,482,2194,1444,
1278,940,488,400,1337,491,66,
370,95,1450,58,486,3,815,422,1742,20,
503,1845,568,53,646,447,
37,378,1626,182,706,953,1050,250,
130,1144,356,897,54,1424,1062,205,
490,521,27,960,205,872,656,1196,
406,463,501,986,2336,
608,152,327,1437,206,163,1336,1067,
480,1986,1173,
2340,1563,386,289,898,
1255,2678,1208,
929,2578,1016,27,123,
12,56,573,562,819,1639,727,
151,35,179,232,749,157,3676,
395,10,1400,263,1839,232,
535,711,29,84,749,593,206,572,243,624,
1562,1328,1597,
1193,312,390,1192,1390,
115,2150,108,37,1209,399,
489,355,529,1919,213,686,953,18,
2596,1325,1550,
424,211,742,1683,409,962,653,39,252,33,
646,355,602,597,1629,1510,
3247,411,
21,1261,665,2570,
207,135,2158,1008,273,169,25,57,
176,267,627,252,280,128,357,754,252,1748,213,
437,1177,954,47,404,1220,431,
2162,
726,2571,204,817,935,
946,489,86,197,521,1046,2025,
4339,496,588,
1360,1984,201,127,
666,342,143,701,55,335,196,520,189,282,1507,292,
680,1409,30,152,
911,1672,327,1649,206,93,
183,299,1634,60,148,730,1705,
133,1190,554,1458,953,
1010,931,39,201,443,2025,
904,754,101,2226,51,781,256,
2180,
709,897,108,686,783,2232,
126,998,77,2674,346,
75,623,209,4520,
487,29,133,1152,110,3541,
1078,638,1394,1583,11,415,
1538,779,1408,
1629,1040,2234,
2077,585,46,1419,683,431,
169,930,2581,69,518,501,336,
901,371,310,1209,57,
777,4333,
89,1719,979,1407,39,
2686,1940,
55,1953,505,153,2147,438,
208,1477,919,298,1414,287,161,
281,2174,489,340,451,57,295,383,664,
20,783,715,1033,1482,
210,813,92,426,6,1451,698,
943,429,2137,982,539,220,
201,528,1085,143,865,2196,
3690,1267,
1810,753,759,484,561,1058,
931,2687,1006,
1030,797,781,460,374,366,
1016,2355,60,
2974,1698,
168,811,
564,3157,1741,
134,2529,310,682,
228,1261,220,875,1334,10,1518,
375,489,1480,249,197,235,1570,
2404,95,73,777,849,464,122,
678,738,266,293,2416,254,649,
429,94,518,1204,191,585,1032,691,
762,74,591,340,282,697,2473,7,
296,2314,662,1392,
5107,
125,3445,
1752,35,176,1068,749,1049,327,
317,736,161,1161,1446,228,215,
1009,3777,
153,338,4183,509,200,
1854,2900,376,176,
572,449,1300,415,1752,
469,626,499,1513,675,455,292,546,
19,1454,1204,924,1329,326,
143,921,544,620,680,
1639,3183,
1084,1383,130,233,1339,
2055,635,2254,
712,36,998,2776,
231,804,619,2144,1065,
1233,776,291,2006,
2603,232,270,1564,
713,78,62,1410,1494,
119,74,765,139,157,341,1304,213,1969,11,353,
892,276,938,115,198,850,
1239,1443,496,
253,345,2080,579,970,
557,1133,500,857,883,1341,211,
512,750,258,1519,826,
10,403,528,710,745,1257,1292,
1573,3322,
284,3040,
1656,919,1286,320,375,183,
327,133,2294,466,183,1077,
687,937,438,596,2487,
1132,795,1039,1386,
861,932,1975,277,
584,495,745,578,1084,287,376,
1223,1458,136,349,629,362,250,79,
2306,2048,
383,220,1180,102,1534,1343,608,
96,2189,765,1117,
747,2301,211,268,1948,
246,222,126,78,246,534,585,329,1799,710,
1317,330,3424,45,
1320,794,2688,681,
1140,3074,
3276,1409,347,137,68,185,
530,1037,224,572,1375,
147,1499,25,90,99,494,1839,130,382,181,
3167,1399,734,
913,461,66,1240,481,284,1167,40,194,
1407,1324,211,101,189,220,552,288,
102,683,1165,1626,174,
79,586,59,874,604,108,70,690,766,1409,
2195,514,
538,2454,1450,34,
630,340,383,1331,351,
83,1586,762,883,278,306,233,290,969,
616,711,1208,657,921,31,243,
1433,1098,789,190,900,196,
840,386,939,174,494,2388,166,
144,381,134,130,1241,713,1487,955,
1184,154,194,2303,106,102,
1,242,1014,23,676,785,82,1238,528,730,
1318,698,2064,964,
704,1281,262,13,456,
923,39,1600,158,783,19,1298,
314,2140,640,790,553,231,229,81,
1971,1080,1371,444,189,
1450,361,135,1558,962,
833,151,1111,865,1080,
241,2066,537,2077,
348,674,2112,
552,3445,415,918,
60,1265,288,433,781,287,1944,
1522,66,174,339,72,628,481,303,821,645,
98,254,225,347,1314,268,341,2169,
596,965,716,117,1016,
734,1007,550,69,338,114,415,751,737,380,
223,1430,121,44,96,236,619,2159,274,
1157,1286,1032,86,69,427,1177,
248,576,429,417,1804,525,
1628,1066,528,161,682,
2804,2232,
464,80,1583,410,765,1325,348,
566,317,899,224,626,735,542,950,230,350,
576,390,1183,1626,
1978,2081,708,41,176,284,
85,392,1994,541,244,
258,3545,68,1229,101,
256,1188,811,1263,1474,45,255,115,
1681,1653,579,
239,1661,48,2075,937,
2232,11,103,
279,448,2281,1233,42,475,587,
2415,1002,683,256,
682,552,2849,
3115,621,119,1038,
1341,597,902,2284,40,
463,2080,1800,610,
5,2330,464,60,303,
920,165,1675,
880,905,1714,
940,140,133,280,57,514,413,380,2408,
332,126,103,657,269,21,3315,
522,1925,1656,
88,1154,611,92,1176,525,450,
3330,749,1130,90,
328,2065,1032,159,1219,
451,978,2554,59,
1378,1210,679,109,619,
1875,92,506,1690,724,
1333,1897,1162,324,
750,371,244,97,832,1740,1360,
106,919,2273,319,1012,
677,1995,427,1416,
46,719,3108,
859,46,673,670,272,1256,424,292,803,
192,1494,1404,388,57,803,343,
3925,370,748,
319,645,203,1709,1133,128,51,264,
3712,
621,600,1709,1161,145,
974,13,472,111,449,513,709,1592,
158,109,2242,1020,1545,352,
809,16,1170,1216,1965,
303,1714,590,1096,639,166,
420,397,290,278,1000,104,941,1604,84,139,
1504,1490,966,
1006,1036,942,406,1170,509,89,
626,954,512,194,212,1248,231,
492,1412,3122,13,
676,1012,1235,720,188,1391,
1143,1732,754,126,564,360,426,
808,506,
781,54,2048,1532,178,
2855,332,640,618,113,
1231,867,347,537,615,229,325,1318,
2696,176,402,1273,289,
1553,1199,109,493,35,1500,544,
272,223,372,1549,571,1421,
62,102,58,3184,22,997,37,1001,
87,7,551,352,791,2517,226,152,
1719,203,566,483,340,186,738,
1481,778,953,321,1855,
202,3474,748,
421,807,388,1320,1665,465,
123,124,3008,107,138,287,1479,
38,409,791,124,1551,2052,
2548,1750,68,683,
32,1528,1706,1553,
313,2244,107,2201,75,
856,1321,
628,1906,171,484,1362,
1042,668,1345,1567,
1216,1443,1164,1491,
893,229,115,654,90,1597,750,1153,
67,128,424,3885,450,
546,1251,
975,359,1439,
321,3,115,271,394,1455,101,1425,310,
815,2019,1105,348,961,
1781,2279,120,533,
1633,61,1808,1004,255,108,
471,1264,595,1284,
58,974,417,
1019,877,
1077,680,35,1198,62,1234,634,
1899,355,
1445,1400,155,459,841,447,428,49,
718,807,1409,
318,844,1118,677,266,732,119,
1113,173,600,1272,2290,
99,1449,575,255,578,883,
1227,959,877,1394,156,
1324,81,51,151,164,3346,
2939,589,1441,88,244,
636,147,4677,
526,1073,1139,405,284,332,
1301,1583,1278,313,60,
520,39,741,1135,13,678,13,68,1489,
218,184,134,3457,1274,
1802,227,1551,68,1752,
15,605,696,3041,409,
692,1659,2680,
725,1302,784,612,783,331,
28,532,701,644,1100,687,128,915,144,
938,1291,1397,503,913,
1851,1865,545,220,
338,124,71,111,2401,
1974,801,49,2297,292,
985,470,655,2097,
229,785,208,1397,
361,325,404,62,45,1271,2193,210,
1755,1260,775,213,1062,77,46,
1689,1462,339,
484,354,502,493,205,455,61,343,894,267,126,33,933,
896,805,158,753,240,499,1795,26,
344,624,34,2692,1292,10,
479,1581,115,1913,
440,1643,37,845,764,241,134,134,910,
4030,272,441,
91,197,299,271,1182,1458,513,786,
26,473,3520,407,
181,5163,
385,90,581,2139,1053,543,451,51,
64,429,1389,918,634,501,1439,
175,1130,95,22,1243,828,503,154,280,153,177,440,61,
1210,633,2048,364,27,463,149,4,66,448,
1731,465,664,1107,643,522,72,
663,475,
280,963,504,4,501,1853,38,181,36,
1182,779,106,164,468,109,1194,403,170,
681,4364,
633,484,977,317,655,1285,325,
3440,225,662,872,
42,117,698,620,2064,123,
539,529,438,814,320,493,713,608,
310,1569,2626,507,
1509,484,269,2515,
1438,3190,13,
1549,717,906,309,62,298,881,
757,502,225,512,164,3175,
116,4836,376,50,
82,131,783,465,309,2489,315,
1523,1371,1520,1026,
107,302,507,552,1447,1827,
2170,1411,1412,
496,86,396,725,283,1233,437,63,382,268,
1539,2955,793,85,
684,363,1532,15,315,1541,
263,307,1136,508,1752,55,
127,910,252,1161,2099,
226,2560,684,1110,
879,1473,1492,858,18,
1413,224,140,182,675,900,347,
519,1113,697,712,582,1165,292,
234,678,815,760,968,634,593,
2099,568,1410,423,44,
1754,159,356,1921,
528,2195,580,138,206,615,235,4,
154,1334,954,2468,
34,701,538,691,
2636,158,192,38,434,926,
137,317,341,748,1220,1482,729,290,18,
2418,
509,310,1290,80,744,2436,15,
4112,
780,75,261,2509,708,
29,308,
242,1456,
2032,449,287,1015,352,62,1127,
1638,865,525,423,
423,1121,379,376,1247,14,
1361,179,1546,559,692,233,
3702,56,79,410,999,
689,328,1436,799,1874,291,
30,2342,80,1033,139,1654,
268,198,108,33,1215,1124,217,300,1753,218,
260,104,1335,2007,833,514,244,134,
1850,2808,701,
2874,562,1826,
216,140,848,329,86,3601,252,
623,685,218,216,1360,1411,
35,230,3401,363,1134,
1263,117,171,1472,794,
551,629,1122,220,250,449,622,1128,223,
990,308,1007,1026,
739,110,324,1400,544,24,557,
1490,1749,7,1678,163,
1268,883,741,513,1617,
1232,875,669,635,1123,272,497,
3003,794,1108,494,
3387,1721,
1073,1444,356,53,1556,
377,1106,243,928,125,83,1276,736,
333,561,993,805,2241,155,
870,219,572,1128,906,380,
172,934,304,379,83,957,51,111,347,116,1263,94,
1164,2064,
307,1245,918,1024,139,
629,88,793,2332,
306,1389,380,2072,815,139,
188,997,122,594,2259,174,42,92,
954,532,1668,1493,124,
170,372,1659,149,399,255,874,462,
249,418,1584,141,73,553,2396,
2388,241,686,394,
95,2331,
953,379,295,740,386,2206,
983,219,273,70,1649,397,849,698,
2024,961,195,1346,
1495,919,1168,184,174,272,541,
601,313,1546,366,778,
2018,1270,
136,3164,1077,
252,497,1723,1598,
455,100,372,2970,1122,322,55,
3177,1227,
61,538,414,438,1629,1762,
1519,930,887,584,
4,1841,2077,407,918,
575,50,509,447,248,1783,220,1358,
1302,680,635,236,1289,
821,657,1122,844,210,1083,
81,193,3674,42,2,116,
355,314,1400,257,456,
643,969,200,3041,86,498,
1026,702,197,409,1466,
396,4200,335,
1256,795,169,192,138,463,519,432,788,
1343,379,1551,1191,
69,581,752,271,2504,1111,
31,238,1728,99,2728,
339,727,2346,1291,38,
219,1896,56,1576,411,
1643,487,897,1012,1039,
660,112,627,1725,264,351,826,
614,914,310,52,633,194,299,851,694,
1258,418,804,1051,
25,1980,922,243,1464,
2023,1795,1244,
59,45,1160,720,7,825,664,1501,383,
2241,
2967,554,
1190,1524,71,1388,271,240,64,485,124,
999,390,1429,3,544,908,1035,
422,1860,574,451,68,649,
656,187,1193,17,658,327,243,1796,
33,780,168,228,84,171,881,1426,
1028,22,217,876,1017,911,74,
299,1298,287,595,11,819,264,137,409,191,409,
1778,165,1118,
590,1015,1338,962,358,1142,
1404,536,
1189,88,882,1798,1241,
2365,1376,429,
76,1535,846,1822,
49,22,1056,65,79,744,189,506,2612,
993,651,314,373,245,23,619,1214,858,
194,2528,1262,983,376,
965,1986,742,404,59,84,177,642,304,
1321,448,95,2494,584,
117,280,873,164,202,
2230,1483,759,721,82,
703,2601,306,90,436,450,361,175,
84,1525,95,593,415,630,428,
754,1848,1435,
1720,1482,558,5,124,60,92,331,67,
118,1565,480,162,3030,
283,805,58,3195,1052,
524,344,1122,1052,1201,853,143,122,
2725,1149,1240,159,
994,3274,134,494,244,
908,1889,1473,66,
485,803,379,903,1288,
2327,2947,88,
254,2286,1791,190,
829,16,374,912,852,2298,174,
199,617,2516,234,1382,223,
766,181,618,604,413,861,718,782,
807,258,946,966,445,186,
259,415,1041,330,2890,113,79,
1933,390,630,668,1710,137,
506,2799,1428,
814,147,1591,
752,1549,
800,3348,
347,772,754,93,23,842,1736,660,141,
865,329,612,708,639,972,910,
1345,211,1228,495,
57,385,2533,421,246,
452,858,1335,908,531,27,
1815,87,1298,724,171,514,
1357,569,1632,413,1164,
1660,1064,1750,313,
2,1527,207,2088,1580,
1381,558,1347,848,345,881,
286,2965,463,244,515,739,
571,208,552,25,383,1164,164,939,596,13,559,4,
45,1401,2070,285,298,
2727,195,672,289,1493,
436,1422,314,402,280,288,8,206,2009,
27,854,531,1661,22,394,632,223,708,
792,2585,
425,125,2528,
2758,91,386,1201,24,
309,239,275,248,2480,228,1370,
782,8,828,1165,403,195,257,905,
474,3215,729,345,
586,445,3837,
605,1215,1278,1357,
801,2601,724,6,266,
769,667,257,400,559,1247,1139,333,
860,1819,1984,
384,14,642,62,2595,152,730,215,
706,1097,884,944,301,
2605,169,452,28,1405,
182,863,
602,232,1788,46,
2395,32,1499,941,79,137,
410,511,504,162,396,243,270,1548,950,
214,386,101,2547,689,
589,730,1022,1294,241,
1130,47,1136,1506,297,73,
141,4466,194,204,
854,351,839,35,88,1012,54,152,420,335,52,68,1206,
257,2122,2174,9,147,546,156,
1396,1026,970,270,291,
585,1247,734,55,1850,831,95,
412,215,1919,293,296,679,759,836,
237,685,1054,239,1245,910,
1398,1415,971,714,523,
846,266,86,394,2976,123,114,
610,1130,232,102,1880,883,
919,814,63,285,401,151,1457,
683,2608,414,80,24,
936,512,388,73,19,294,275,
537,230,1362,599,921,1063,605,
1987,170,658,465,319,189,489,108,433,
196,466,706,830,1097,606,1466,
369,928,672,584,1300,1307,120,
775,551,1195,570,1896,
417,1157,48,110,108,359,305,1165,830,
432,1958,897,107,2085,
366,26,255,263,938,1827,786,174,271,
3168,2282,
1169,1967,1017,513,141,
957,931,114,1604,697,492,134,
232,127,1177,710,958,
416,670,1478,1412,
400,3169,1437,
688,1775,1933,
238,1259,568,214,395,145,1773,797,
1776,974,932,961,543,10,10,278,
1217,432,976,195,814,1209,494,
145,619,1604,107,456,1668,
24,676,1570,339,1118,530,450,93,
18,2443,668,210,1350,49,171,
240,1319,2695,433,
1696,528,509,376,329,222,286,
1931,3067,
461,95,1103,679,778,53,671,1285,
3754,1001,144,
1207,1704,402,1438,
977,523,1559,178,524,212,1316,
1375,107,160,362,
1601,434,745,
884,736,1624,791,
618,2079,1214,
1153,2391,230,348,
631,1425,1000,1251,581,
386,220,380,1795,2686,
1766,1716,1390,
751,978,1529,54,
744,953,794,883,185,
1296,40,356,1637,1395,712,
185,635,1566,23,222,2017,
1094,378,39,1572,
1199,2671,157,
761,2902,1015,
206,304,3284,1021,421,
2478,622,2087,
187,572,3227,
372,2244,23,1104,264,56,432,839,
3245,49,787,
1126,266,31,3080,898,
340,1934,536,58,579,870,338,553,
917,228,2972,107,211,945,
349,393,359,393,810,310,807,287,339,
505,1126,2046,752,411,
1294,297,251,744,1813,
4459,
403,532,486,690,774,1709,
162,1046,666,415,1247,60,850,102,477,
434,7,804,3271,604,
354,945,444,439,313,245,1223,763,
1165,777,
1871,1175,51,
3089,680,
470,110,293,710,1437,244,636,497,579,
948,193,276,107,1826,
36,1614,450,425,768,1630,306,78,
23,1409,921,365,1485,324,
1125,978,825,334,56,669,265,523,393,47,94,
113,313,4,1196,1831,971,
2097,1610,1598,
1123,146,207,394,
467,4147,
1172,961,1524,1390,13,331,
573,671,846,1532,
695,78,2034,281,826,776,628,
291,888,737,521,1126,37,858,854,11,
583,548,19,2216,
367,1724,1476,245,1279,
1684,2772,33,49,271,474,
8,57,250,1819,458,430,1401,
1453,7,2017,112,405,1249,
711,444,694,1368,569,409,15,
322,1499,305,182,
357,183,342,1408,358,219,113,1534,513,
371,621,195,3587,221,
622,2474,466,227,309,213,92,
146,1262,429,140,588,700,1098,127,
326,618,1801,1319,544,309,
2401,608,299,
387,784,1056,802,292,1483,
812,1628,923,996,623,
1063,987,2587,
453,2416,1113,
848,1444,159,2330,
407,325,1796,483,575,
261,783,323,2028,806,575,
336,1948,
2917,1959,
998,891,1302,128,29,567,
1018,557,1506,871,576,193,433,
613,26,191,376,511,1203,1934,
129,285,1252,1675,1309,
40,602,859,312,1119,2532,
2950,
177,775,793,570,648,266,180,40,303,355,1322,
776,1988,2403,
72,3941,799,
1048,459,425,715,962,1066,163,225,361,
653,484,756,1323,548,892,
3659,883,
1443,670,680,148,782,371,652,282,
558,805,1415,1554,
1000,186,207,357,848,1331,52,1080,
604,180,1041,1153,1230,903,
1120,1129,122,1183,826,
1306,1576,
13,875,116,1637,1824,
796,2002,34,167,237,571,1207,
166,320,1850,792,553,518,
43,856,1030,476,565,36,
939,374,1228,867,1146,
2244,1442,226,704,
2312,718,245,612,428,
294,3174,20,182,
624,861,425,41,1406,1999,
1212,1201,1164,1618,81,
391,154,1385,1227,1089,
1758,786,127,366,910,
562,275,798,859,737,380,638,428,
156,1604,1724,1337,526,
197,596,139,474,472,563,958,1457,
1441,478,80,1300,116,192,127,1016,
1342,578,127,2838,135,
483,732,61,191,665,196,682,844,213,164,353,36,
541,134,1731,
1175,1098,1238,305,
335,111,778,1833,
73,1423,39,80,1922,276,733,590,
788,1040,355,25,435,2775,
217,53,124,611,231,13,472,1626,203,
221,43,634,1952,1635,56,
1579,415,539,1986,
640,275,710,255,452,1243,
444,1114,3238,
543,154,1329,503,713,98,132,779,
41,2565,900,41,140,14,
1241,975,860,946,1077,81,
960,1399,749,80,1852,
457,1600,376,1360,430,495,146,
4076,714,652,
1856,832,681,
521,209,1483,522,1659,191,
502,360,
204,1238,513,239,93,
44,207,2030,712,359,646,154,766,
743,857,108,1169,
2048,590,1285,282,778,302,41,
1029,984,489,572,1804,438,
1772,1427,657,655,518,
714,133,30,487,1612,748,391,178,
50,3,4347,
22,2066,1436,1216,
7,1700,1102,508,655,96,895,
1285,269,810,1226,274,79,266,
323,1882,251,840,
1347,1060,481,144,251,899,882,
2154,269,572,215,859,59,813,144,364,
3278,907,128,48,
2693,482,216,35,1747,
1183,67,
1430,1766,29,1066,
3301,255,1821,
184,603,288,452,558,1099,1414,2,232,
300,354,1418,289,1327,
419,896,1789,951,383,
1865,303,
1934,843,144,422,309,386,
3014,581,
2031,104,1866,523,";
    }
}
