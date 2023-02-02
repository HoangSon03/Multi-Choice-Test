using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for webui
/// </summary>
public class webui
{
    public webui()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<string> UrlRoutes()
    {
        List<string> list = new List<string>();
        list.Add("webTrangChu|trang-chu|~/Default.aspx");

        //module login
        list.Add("webRegister|register-account|~/web_module/Register.aspx");
        list.Add("webLogin|login-account|~/web_module/Login.aspx");

        //List Game kiểm tra
        list.Add("webBaiKiemTra|bai-kiem-tra-{id_khoi}.html|~/web_module/web_ListMonHoc.aspx");
        //List Game luyện tập
        list.Add("webLuyenTap|bai-luyen-tap-{id_khoi}.html|~/web_module/web_ListMonHoc2.aspx");

        //list game trắc nghiệm
        list.Add("webListGame|list-game-{id_khoi}.html|~/web_module/web_ListGame.aspx");
        list.Add("webListGameDetail|list-game/{id_khoi}/{id_mon}.html|~/web_module/web_ListGameDetail.aspx");

        //Toán lớp 1 tập 1 
        //list game trắc nghiệm toán tập 1 bài 1
        list.Add("webGameMath1Bai1Trang89|game-toan-1-bai-1-trang-8-9|~/web_module/GameMath1/Bai1/web__Maths1_lesson1_page8_9.aspx");
        list.Add("webGameMath1Bai1Trang1011|game-toan-1-bai-1-trang-10-11|~/web_module/GameMath1/Bai1/web__Maths1_lesson1_page10_11.aspx");
        list.Add("webGameMath1Bai1Trang1213|game-toan-1-bai-1-trang-12-13|~/web_module/GameMath1/Bai1/web__Maths1_lesson1_page12_13.aspx");
        //list game trắc nghiệm toán tập 1 bài 2
        list.Add("webGameMath1Bai2Trang1415|game-toan-1-bai-2-trang-14-15|~/web_module/GameMath1/Bai2/web__Maths1_lesson2_page14_15.aspx");
        list.Add("webGameMath1Bai2Trang1617|game-toan-1-bai-2-trang-16-17|~/web_module/GameMath1/Bai2/web__Maths1_lesson2_page16_17.aspx");
        list.Add("webGameMath1Bai2Trang1819|game-toan-1-bai-2-trang-18-19|~/web_module/GameMath1/Bai2/web__Maths1_lesson2_page18_19.aspx");
        //list game trắc nghiệm toán tập 1 bài 3
        list.Add("webGameMath1Bai3Trang2021|game-toan-1-bai-3-trang-20-21|~/web_module/GameMath1/Bai3/web__Maths1_lesson3_page20_21.aspx");
        list.Add("webGameMath1Bai3Trang2223|game-toan-1-bai-3-trang-22-23|~/web_module/GameMath1/Bai3/web__Maths1_lesson3_page22_23.aspx");
        //list game trắc nghiệm toán tập 1 bài 4
        list.Add("webGameMath1Bai3Trang2425|game-toan-1-bai-4-trang-24-25|~/web_module/GameMath1/Bai4/web__Maths1_lesson4_page24_25.aspx");
        list.Add("webGameMath1Bai3Trang2627|game-toan-1-bai-4-trang-26-27|~/web_module/GameMath1/Bai4/web__Maths1_lesson4_page26_27.aspx");
        list.Add("webGameMath1Bai3Trang2829|game-toan-1-bai-4-trang-28-29|~/web_module/GameMath1/Bai4/web__Maths1_lesson4_page28_29.aspx");
        list.Add("webGameMath1Bai3Trang3031|game-toan-1-bai-4-trang-30-31|~/web_module/GameMath1/Bai4/web__Maths1_lesson4_page30_31.aspx");
        //list game trắc nghiệm toán tập 1 bài 5
        list.Add("webGameMath1Bai5Trang3233|game-toan-1-bai-5-trang-32-33|~/web_module/GameMath1/Bai5/web__Maths1_lesson5_page32_33.aspx");
        list.Add("webGameMath1Bai5Trang3435|game-toan-1-bai-5-trang-34-35|~/web_module/GameMath1/Bai5/web__Maths1_lesson5_page34_35.aspx");
        list.Add("webGameMath1Bai5Trang3637|game-toan-1-bai-5-trang-36-37|~/web_module/GameMath1/Bai5/web__Maths1_lesson5_page36_37.aspx");
        //list game trắc nghiệm toán tập 1 bài 6
        list.Add("webGameMath1Bai6Trang3839|game-toan-1-bai-6-trang-38-39|~/web_module/GameMath1/Bai6/web__Maths1_lesson6_page38_39.aspx");
        list.Add("webGameMath1Bai6Trang4041|game-toan-1-bai-6-trang-40-41|~/web_module/GameMath1/Bai6/web__Maths1_lesson6_page40_41.aspx");
        list.Add("webGameMath1Bai6Trang4243|game-toan-1-bai-6-trang-42-43|~/web_module/GameMath1/Bai6/web__Maths1_lesson6_page42_43.aspx");
        list.Add("webGameMath1Bai6Trang4445|game-toan-1-bai-6-trang-44-45|~/web_module/GameMath1/Bai6/web__Maths1_lesson6_page44_45.aspx");
        //list game trắc nghiệm toán tập 1 bài 7
        list.Add("webGameMath1Bai7Trang4647|game-toan-1-bai-7-trang-46-47|~/web_module/GameMath1/Bai7/web__Maths1_lesson7_page46_47.aspx");
        list.Add("webGameMath1Bai7Trang4849|game-toan-1-bai-7-trang-48-49|~/web_module/GameMath1/Bai7/web__Maths1_lesson7_page48_49.aspx");
        list.Add("webGameMath1Bai8Trang5051|game-toan-1-bai-8-trang-50-51|~/web_module/GameMath1/Bai8/web__Maths1_lesson8_page50_51.aspx");
        list.Add("webGameMath1Bai8Trang5253|game-toan-1-bai-8-trang-52-53|~/web_module/GameMath1/Bai8/web__Maths1_lesson8_page52_53.aspx");
        //list game trắc nghiệm toán tập 1 bài 9
        list.Add("webGameMath1Bai8Trang54|game-toan-1-bai-9-trang-54|~/web_module/GameMath1/Bai9/web__Maths1_lesson9_page54.aspx");
        list.Add("webGameMath1Bai8Trang55|game-toan-1-bai-9-trang-55|~/web_module/GameMath1/Bai9/web__Maths1_lesson9_page55.aspx");
        //list game trắc nghiệm toán tập 1 bài 10
        list.Add("webGameMath1Bai10Trang5657|game-toan-1-bai-10-trang-56-57|~/web_module/GameMath1/Bai10(56-59)/web__Maths1_lesson10_page56_57.aspx");
        list.Add("webGameMath1Bai10Trang5859|game-toan-1-bai-10-trang-58-59|~/web_module/GameMath1/Bai10(56-59)/web__Maths1_lesson10_page58_59.aspx");
        list.Add("webGameMath1Bai10Trang6465|game-toan-1-bai-10-trang-64-65|~/web_module/GameMath1/Bai10/web__Maths1_lesson10_page64_65.aspx");
        list.Add("webGameMath1Bai10Trang6667|game-toan-1-bai-10-trang-66-67|~/web_module/GameMath1/Bai10/web__Maths1_lesson10_page66_67.aspx");
        //list game trắc nghiệm toán tập 1 bài 11
        list.Add("webGameMath1Bai11Trang6869|game-toan-1-bai-11-trang-68-69|~/web_module/GameMath1/Bai11/web__Maths1_lesson11_page68_69.aspx");
        list.Add("webGameMath1Bai11Trang7071|game-toan-1-bai-11-trang-70-71|~/web_module/GameMath1/Bai11/web__Maths1_lesson11_page70_71.aspx");
        list.Add("webGameMath1Bai11Trang7273|game-toan-1-bai-11-trang-72-73|~/web_module/GameMath1/Bai11/web__Maths1_lesson11_page72_73.aspx");
        list.Add("webGameMath1Bai11Trang7475|game-toan-1-bai-11-trang-74-75|~/web_module/GameMath1/Bai11/web__Maths1_lesson11_page74_75.aspx");
        list.Add("webGameMath1Bai11Trang7677|game-toan-1-bai-11-trang-76-77|~/web_module/GameMath1/Bai11/web__Maths1_lesson11_page76_77.aspx");
        list.Add("webGameMath1Bai11Trang7879|game-toan-1-bai-11-trang-78-79|~/web_module/GameMath1/Bai11/web__Maths1_lesson11_page78_79.aspx");
        list.Add("webGameMath1Bai12Trang8081|game-toan-1-bai-12-trang-80-81|~/web_module/GameMath1/Bai12/web__Maths1_lesson12_page80_81.aspx");
        list.Add("webGameMath1Bai12Trang8283|game-toan-1-bai-12-trang-82-83|~/web_module/GameMath1/Bai12/web__Maths1_lesson12_page82_83.aspx");
        list.Add("webGameMath1Bai12Trang8485|game-toan-1-bai-12-trang-84-85|~/web_module/GameMath1/Bai12/web__Maths1_lesson12_page84_85.aspx");
        //list game trắc nghiệm toán tập 1 bài 17
        list.Add("webGameMath1Bai17Trang102103|game-toan-1-bai-17-trang-102-103|~/web_module/GameMath1/Bai17/web__Maths1_lesson17_page102_103.aspx");
        list.Add("webGameMath1Bai17Trang104105|game-toan-1-bai-17-trang-104-105|~/web_module/GameMath1/Bai17/web__Maths1_lesson17_page104_105.aspx");
        //list game trắc nghiệm toán tập 1 bài 13
        list.Add("webGameMath1Bai13Trang8687|game-toan-1-bai-13-trang-86-87|~/web_module/GameMath1/Bai13/web__Maths1_lesson13_page86_87.aspx");
        list.Add("webGameMath1Bai13Trang8889|game-toan-1-bai-13-trang-88-89|~/web_module/GameMath1/Bai13/web__Maths1_lesson13_page88_89.aspx");
        list.Add("webGameMath1Bai13Trang9091|game-toan-1-bai-13-trang-90-91|~/web_module/GameMath1/Bai13_trang90_91/web__Maths1_lesson13_page90_91.aspx");
        //list game trắc nghiệm toán tập 1 bài 14
        list.Add("webGameMath1Bai14Trang9293|game-toan-1-bai-14-trang-92-93|~/web_module/GameMath1/Bai14_trang92_93/web__Maths1_lesson14_page92_93.aspx");
        list.Add("webGameMath1Bai14Trang9495|game-toan-1-bai-14-trang-94-95|~/web_module/GameMath1/Bai14/web__Maths1_lesson14_page94_95.aspx");
        //list game trắc nghiệm toán tập 1 bài 15
        list.Add("webGameMath1Bai13Trang9697|game-toan-1-bai-15-trang-96-97|~/web_module/GameMath1/Bai15/web__Maths1_lesson15_page96_97.aspx");
        list.Add("webGameMath1Bai15Trang9899|game-toan-1-bai-15-trang-98-99|~/web_module/GameMath1/Bai15/web__Maths1_lesson15_page98_99.aspx");
        //list game trắc nghiệm toán tập 1 bài 16
        list.Add("webGameMath1Bai16Trang100101|game-toan-1-bai-16-trang-100-101|~/web_module/GameMath1/Bai16/web__Maths1_lesson16_page100_101.aspx");
        
        // Toán lớp 1 tập 2
        //list game trắc nghiệm toán tập 1 bài 18
        list.Add("webGameMath1Bai18Trang108109|game-toan-1-bai-18-trang-108-109|~/web_module/GameMath1/Bai18/web__Maths1_lesson18_page108_109.aspx");
        list.Add("webGameMath1Bai18Trang106107|game-toan-1-bai-18-trang-106-107|~/web_module/GameMath1/Bai18/web__Maths1_lesson18_page106_107.aspx");
        //list game trắc nghiệm toán tập 1 bài 19
        list.Add("webGameMath1Bai19Trang110111|game-toan-1-bai-19-trang-110-111|~/web_module/GameMath1/Bai19/web__Maths1_lesson19_page110_111.aspx");
        //list game trắc nghiệm toán tập 1 bài 20
        list.Add("webGameMath1Bai20Trang112113|game-toan-1-bai-20-trang-112-113|~/web_module/GameMath1/Bai20/web__Maths1_lesson20_page112_113.aspx");
        //list game trắc nghiệm toán tập 2 bài 21
        list.Add("webGameMath1Bai21Trang0405|game-toan-1-tap-2-bai-21-trang-04-05|~/web_module/GameMath1/Bai21/web__Maths1_lesson21_T2_page04_05.aspx");
        list.Add("webGameMath1Bai21Trang0607|game-toan-1-bai-21-trang-6-7|~/web_module/GameMath1/Bai21/web__Maths1_lesson21_page6_7.aspx");
        list.Add("webGameMath1Bai21Trang1011|game-toan-1-bai-21-trang-10-11|~/web_module/GameMath1/Bai21/web__Maths1_lesson21_page10_11.aspx");
        list.Add("webGameMath1Bai21Trang1213|game-toan-1-bai-21-trang-12-13|~/web_module/GameMath1/Bai21/web__Maths1_lesson21_page12_13.aspx");
        list.Add("webGameMath1Bai21Trang1415|game-toan-1-bai-21-trang-14-15|~/web_module/GameMath1/Bai21/web__Maths1_lesson21_page14_15.aspx");
        //list game trắc nghiệm toán tập 2 bài 22
        list.Add("webGameMath1Bai22Trang1819|game-toan-1-bai-22-trang-18-19|~/web_module/GameMath1/Bai22/web__Maths1_lesson22_page18_19.aspx");
        list.Add("webGameMath1Bai22Trang1617|game-toan-1-bai-22-trang-16-17|~/web_module/GameMath1/Bai22/web__Maths1_lesson22_page16_17.aspx");
        list.Add("webGameMath1Bai22Trang2021|game-toan-1-bai-22-trang-20-21|~/web_module/GameMath1/Bai22/web__Maths1_lesson22_page20_21.aspx");
        //list game trắc nghiệm toán tập 2 bài 23
        list.Add("webGameMath1Bai23Trang2223|game-toan-1-bai-23-trang-22-23|~/web_module/GameMath1/Bai23/web__Maths1_lesson23_page22_23.aspx");
        //list game trắc nghiệm toán tập 2 bài 24
        list.Add("webGameMath1Bai24Trang2425|game-toan-1-bai-24-trang-24-25|~/web_module/GameMath1/Bai24/web__Maths1_lesson24_page24_25.aspx");
        list.Add("webGameMath1Bai24Trang2627|game-toan-1-bai-24-trang-26-27|~/web_module/GameMath1/Bai24/web__Maths1_lesson24_page26_27.aspx");
        //list game trắc nghiệm toán tập 2 bài 25
        list.Add("webGameMath1Bai25Trang3031|game-toan-1-bai-25-trang-30-31|~/web_module/GameMath1/Bai25/web__Maths1_lesson25_page30_31.aspx");
        //list game trắc nghiệm toán tập 2 bài 26
        list.Add("webGameMath1Bai26Trang3233|game-toan-1-bai-26-trang-32-33|~/web_module/GameMath1/Bai26/web__Maths1_lesson26_page32_33.aspx");
        list.Add("webGameMath1Bai26Trang3435|game-toan-1-bai-26-trang-34-35|~/web_module/GameMath1/Bai26_trang34_35/web__Maths1_lesson26_page34_35.aspx");


        //list game trắc nghiệm toán tập 2 bài 27
        list.Add("webGameMath1Bai27Trang3637|game-toan-1-bai-27-trang-36-37|~/web_module/GameMath1/Bai27/web__Maths1_lesson27_page36_37.aspx");
        list.Add("webGameMath1Bai27Trang3839|game-toan-1-bai-27-trang-38-39|~/web_module/GameMath1/Bai27/web__Maths1_lesson27_page38_39.aspx");


        //list game trắc nghiệm toán tập 2 bài 28
        list.Add("webGameMath1Bai28Trang4041|game-toan-1-bai-28-trang-40-41|~/web_module/GameMath1/Bai28/web__Maths1_lesson28_page40_41.aspx");
        list.Add("webGameMath1Bai28Trang4243|game-toan-1-bai-28-trang-42-43|~/web_module/GameMath1/Bai28/web__Maths1_lesson28_page42_43.aspx");

        //list game trắc nghiệm toán tập 2 bài 29
        list.Add("webGameMath1Bai29Trang4445|game-toan-1-bai-29-trang-44-45|~/web_module/GameMath1/Bai29/web__Maths1_lesson29_page44_45.aspx");
        list.Add("webGameMath1Bai29Trang4647|game-toan-1-bai-29-trang-46-47|~/web_module/GameMath1/Bai29/web__Maths1_lesson29_page46_47.aspx");

        //list game trắc nghiệm toán tập 2 bài 30
        list.Add("webGameMath1Bai30Trang5051|game-toan-1-bai-30-trang-50-51|~/web_module/GameMath1/Bai30/web__Maths1_lesson30_page50_51.aspx");
      
        //list game trắc nghiệm toán tập 2 bài 31
        list.Add("webGameMath1Bai31Trang5253|game-toan-1-bai-31-trang-52-53|~/web_module/GameMath1/Bai31/web__Maths1_lesson31_page52_53.aspx");
        list.Add("webGameMath1Bai31Trang5455|game-toan-1-bai-31-trang-54-55|~/web_module/GameMath1/Bai31/web__Maths1_lesson31_page54_55.aspx");
        list.Add("webGameMath1Bai31Trang5657|game-toan-1-bai-31-trang-56-57|~/web_module/GameMath1/Bai31/web__Maths1_lesson31_page56_57.aspx");

        //list game trắc nghiệm toán tập 2 bài 32
        list.Add("webGameMath1Bai32Trang5859|game-toan-1-bai-32-trang-58-59|~/web_module/GameMath1/Bai32/web__Maths1_lesson32_page58_59.aspx");
        list.Add("webGameMath1Bai32Trang6061|game-toan-1-bai-32-trang-60-61|~/web_module/GameMath1/Bai32/web__Maths1_lesson32_page60_61.aspx");
        list.Add("webGameMath1Bai32Trang6263|game-toan-1-bai-32-trang-62-63|~/web_module/GameMath1/Bai32/web__Maths1_lesson32_page62_63.aspx");

        //list game trắc nghiệm toán tập 2 bài 33
        list.Add("webGameMath1Bai33Trang6667|game-toan-1-bai-33-trang-66-67|~/web_module/GameMath1/Bai33/web__Maths1_lesson33_page66_67.aspx");
        list.Add("webGameMath1Bai33Trang6869|game-toan-1-bai-33-trang-68-69|~/web_module/GameMath1/Bai33/web__Maths1_lesson33_page68_69.aspx");
        list.Add("webGameMath1Bai33Trang7071|game-toan-1-bai-33-trang-70-71|~/web_module/GameMath1/Bai33/web__Maths1_lesson33_page70_71.aspx");

        //list game trắc nghiệm toán tập 2 bài 34
        list.Add("webGameMath1Bai34Trang7273|game-toan-1-bai-34-trang-72-73|~/web_module/GameMath1/Bai34/web__Maths1_lesson34_page72_73.aspx");
        list.Add("webGameMath1Bai34Trang7475|game-toan-1-bai-34-trang-74-75|~/web_module/GameMath1/Bai34/web__Maths1_lesson34_page74_75.aspx");

        //list game trắc nghiệm toán tập 2 bài 35
        list.Add("webGameMath1Bai35Trang7879|game-toan-1-bai-35-trang-78-79|~/web_module/GameMath1/Bai35/web__Maths1_lesson35_page78_79.aspx");
        list.Add("webGameMath1Bai35Trang7576|game-toan-1-bai-35-trang-75-76|~/web_module/GameMath1/Bai35/web__Maths1_lesson35_page75_76.aspx");
        //list game trắc nghiệm toán tập 2 bài 36
        list.Add("webGameMath1Bai36Trang8283|game-toan-1-bai-36-trang-82-83|~/web_module/GameMath1/Bai36/web__Maths1_lesson36_page82_83.aspx");

        //list game trắc nghiệm toán tập 2 bài 37
        list.Add("webGameMath1Bai37Trang8485|game-toan-1-bai-37-trang-84-85|~/web_module/GameMath1/Bai37/web__Maths1_lesson37_page84_85.aspx");
        list.Add("webGameMath1Bai37Trang8687|game-toan-1-bai-37-trang-86-87|~/web_module/GameMath1/Bai37/web__Maths1_lesson37_page86_87.aspx");

        //list game trắc nghiệm toán tập 2 bài 38
        list.Add("webGameMath1Bai38Trang8889|game-toan-1-bai-38-trang-88-89|~/web_module/GameMath1/Bai38/web__Maths1_lesson38_page88_89.aspx");
        list.Add("webGameMath1Bai38Trang9091|game-toan-1-bai-38-trang-90-91|~/web_module/GameMath1/Bai38/web__Maths1_lesson38_page90_91.aspx");

        //list game trắc nghiệm toán tập 2 bài 39
        list.Add("webGameMath1Bai39Trang9495|game-toan-1-bai-39-trang-94-95|~/web_module/GameMath1/Bai39/web__Maths1_lesson39_page94_95.aspx");
        list.Add("webGameMath1Bai39Trang9899|game-toan-1-bai-39-trang-98-99|~/web_module/GameMath1/Bai39/web__Maths1_lesson39_page98_99.aspx");
        //list game trắc nghiệm toán tập 2 bài 40
        list.Add("webGameMath1Bai40Trang100101|game-toan-1-bai-40-trang-100-101|~/web_module/GameMath1/Bai40/web__Maths1_lesson40_page100_101.aspx");
        //list game trắc nghiệm toán tập 2 bài 40
        list.Add("webGameMath1Bai40Trang102103|game-toan-1-bai-40-trang-102-103|~/web_module/GameMath1/Bai40/web__Maths1_lesson40_page102_103.aspx");
        //--------------------- TIẾNG VIỆT -------------------------------------------
        //list game trắc nghiệm tiếng việt tập 1 bài 1
        list.Add("webGameTiengViet1Bai1Trang5|game-tiengviet-1-bai-1-trang-5.html|~/web_module/GameTiengViet1/Bai1/web__TiengViet1_lesson1_page14.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 2
        list.Add("webGameTiengViet1Bai2Trang6|game-tiengviet-1-bai-2-trang-6.html|~/web_module/GameTiengViet1/Bai2/web__TiengViet1_Lesson1_page_6_7.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 3
        list.Add("webGameTiengViet1Bai3Trang18|game-tiengviet-1-bai-3-trang-18.html|~/web_module/GameTiengViet1/Bai3/web__TiengViet1_lesson3_page18.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 4
        list.Add("webGameTiengViet1Bai4Trang8|game-tiengviet-1-bai-4-trang-8.html|~/web_module/GameTiengViet1/Bai4/web__TiengViet1_lesson4_page20.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 5
        list.Add("webGameTiengViet1Bai5Trang22|game-tiengviet-1-bai-5-trang-22.html|~/web_module/GameTiengViet1/Bai5/web__TiengViet1_lesson5_page22.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 6
        list.Add("webGameTiengViet1Bai6Trang24|game-tiengviet-1-bai-6-trang-24.html|~/web_module/GameTiengViet1/Bai6/web__TiengViet1_lesson6_page24.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 7
        list.Add("webGameTiengViet1Bai7Trang26|game-tiengviet-1-bai-7-trang-26-27.html|~/web_module/GameTiengViet1/Bai7/web__TiengViet1_lesson7_page_26_27.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 8
        list.Add("webGameTiengViet1Bai8Trang2829|game-tiengviet-1-bai-8-trang-28-29.html|~/web_module/GameTiengViet1/Bai8/web__TiengViet1_lesson8_page_28_29.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 9 
        list.Add("webGameTiengViet1Bai9Trang30|game-tiengviet-1-bai-9-trang-30-31.html|~/web_module/GameTiengViet1/Bai9/web__TiengViet1_lesson9_page_30_31.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 10
        list.Add("webGameTiengViet1Bai10Trang32|game-tiengviet-1-bai-10-trang-32.html|~/web_module/GameTiengViet1/Bai10/web__TiengViet1_lesson10_page_32_33.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 11
        list.Add("webGameTiengViet1Bai11Trang34|game-tiengviet-1-bai-11-trang-34-35.html|~/web_module/GameTiengViet1/Bai11/web__TiengViet1_lesson11_page_34_35.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 12
        list.Add("webGameTiengViet1Bai12Trang36|game-tiengviet-1-bai-12-trang-36.html|~/web_module/GameTiengViet1/Bai12/web__TiengViet1_lesson12_page36.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 13
        list.Add("webGameTiengViet1Bai13Trang38|game-tiengviet-1-bai-13-trang-38.html|~/web_module/GameTiengViet1/Bai13/web__TiengViet1_lesson13_page38.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 14
        list.Add("webGameTiengViet1Bai14Trang40|game-tiengviet-1-bai-14-trang-40.html|~/web_module/GameTiengViet1/Bai14/web__TiengViet1_lesson14_page40.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 16
        list.Add("webGameTiengViet1Bai16Trang44|game-tiengviet-1-bai-16-trang-44.html|~/web_module/GameTiengViet1/Bai16/web__TiengViet1_lesson16_page44.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 17
        list.Add("webGameTiengViet1Bai16Trang46|game-tiengviet-1-bai-17-trang-46.html|~/web_module/GameTiengViet1/Bai17/web__TiengViet1_lesson17_page46.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 18
        list.Add("webGameTiengViet1Bai18Trang48|game-tiengviet-1-bai-18-trang-48.html|~/web_module/GameTiengViet1/Bai18/web__TiengViet1_lesson18_page48_49.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 19
        list.Add("webGameTiengViet1Bai19Trang50|game-tiengviet-1-bai-19-trang-50.html|~/web_module/GameTiengViet1/Bai19/web__TiengViet1_lesson19_page50_51.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 20
        list.Add("webGameTiengViet1Bai20Trang52|game-tiengviet-1-bai-20-trang-52.html|~/web_module/GameTiengViet1/Bai20/web__TiengViet1_lesson20_page52_53.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 21
        list.Add("webGameTiengViet1Bai21Trang54|game-tiengviet-1-bai-21-trang-54.html|~/web_module/GameTiengViet1/Bai21/web__TiengViet1_lesson21_page54_55.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 22
        list.Add("webGameTiengViet1Bai22Trang56|game-tiengviet-1-bai-22-trang-56.html|~/web_module/GameTiengViet1/Bai22/web__TiengViet1_lesson22_page56_57.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 23
        list.Add("webGameTiengViet1Bai23Trang58|game-tiengviet-1-bai-23-trang-58.html|~/web_module/GameTiengViet1/Bai23/web__TiengViet1_lesson23_page58_59.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 24
        list.Add("webGameTiengViet1Bai24Trang60|game-tiengviet-1-bai-24-trang-60.html|~/web_module/GameTiengViet1/Bai24/web__TiengViet1_lesson24_page60.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 25
        list.Add("webGameTiengViet1Bai25Trang62|game-tiengviet-1-bai-25-trang-62.html|~/web_module/GameTiengViet1/Bai25/web__TiengViet1_lesson25_page62.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 26
        list.Add("webGameTiengViet1Bai26Trang64|game-tiengviet-1-bai-26-trang-64.html|~/web_module/GameTiengViet1/Bai26/web__TiengViet1_lesson26_page64.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 27
        list.Add("webGameTiengViet1Bai27Trang66|game-tiengviet-1-bai-27-trang-66.html|~/web_module/GameTiengViet1/Bai27/web__TiengViet1_lesson27_page66.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 28
        list.Add("webGameTiengViet1Bai28Trang68|game-tiengviet-1-bai-28-trang-68.html|~/web_module/GameTiengViet1/Bai28/web__TiengViet1_lesson28_page68.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 29
        list.Add("webGameTiengViet1Bai29Trang70|game-tiengviet-1-bai-29-trang-70.html|~/web_module/GameTiengViet1/Bai29/web__TiengViet1_lesson29_page70.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 30
        list.Add("webGameTiengViet1Bai30Trang72|game-tiengviet-1-bai-30-trang-72.html|~/web_module/GameTiengViet1/Bai30/web__TiengViet1_lesson30_page72.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 31
        list.Add("webGameTiengViet1Bai31Trang74|game-tiengviet-1-bai-31-trang-74.html|~/web_module/GameTiengViet1/Bai31/web__TiengViet1_lesson31_page74.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 32
        list.Add("webGameTiengViet1Bai32Trang76|game-tiengviet-1-bai-32-trang-76.html|~/web_module/GameTiengViet1/Bai32/web__TiengViet1_lesson32_page76.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 33
        list.Add("webGameTiengViet1Bai33Trang78|game-tiengviet-1-bai-33-trang-78.html|~/web_module/GameTiengViet1/Bai33/web__TiengViet1_lesson33_page78.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 34
        list.Add("webGameTiengViet1Bai34Trang80|game-tiengviet-1-bai-34-trang-80.html|~/web_module/GameTiengViet1/Bai34/web_TiengViet1_Lesson34_page80.aspx");//list game trắc nghiệm tiếng việt tập 1 bài 34
        //list game trắc nghiệm tiếng việt tập 1 bài 35
        list.Add("webGameTiengViet1Bai35Trang82|game-tiengviet-1-bai-35-trang-82.html|~/web_module/GameTiengViet1/Bai35/web_TiengViet1_Lesson35_page82.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 36
        list.Add("webGameTiengViet1Bai36Trang84|game-tiengviet-1-bai-36-trang-84.html|~/web_module/GameTiengViet1/Bai36/web__TiengViet1_lesson36_page84_85.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 37
        list.Add("webGameTiengViet1Bai36Trang86|game-tiengviet-1-bai-37-trang-86.html|~/web_module/GameTiengViet1/Bai37/web__TiengViet1_lesson37_page86_87.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 38
        list.Add("webGameTiengViet1Bai38Trang88|game-tiengviet-1-bai-38-trang-88.html|~/web_module/GameTiengViet1/Bai38/web__TiengViet1_Lesson38_page88_89.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 39
        list.Add("webGameTiengViet1Bai39Trang90|game-tiengviet-1-bai-39-trang-90.html|~/web_module/GameTiengViet1/Bai39/web__TiengViet1_Lesson39_page90_91.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 40
        list.Add("webGameTiengViet1Bai40Trang92|game-tiengviet-1-bai-40-trang-92.html|~/web_module/GameTiengViet1/Bai40/web__TiengViet1_Lesson40_page92_93.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 41
        list.Add("webGameTiengViet1Bai41Trang94|game-tiengviet-1-bai-41-trang-94.html|~/web_module/GameTiengViet1/Bai41/web__TiengViet1_Lesson41_page94_95.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 42
        list.Add("webGameTiengViet1Bai42Trang96|game-tiengviet-1-bai-42-trang-96.html|~/web_module/GameTiengViet1/Bai42/web__TiengViet1_Lesson42_page96.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 43
        list.Add("webGameTiengViet1Bai43Trang98|game-tiengviet-1-bai-43-trang-98.html|~/web_module/GameTiengViet1/Bai43/web__TiengViet1_lesson43_page98.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 44
        list.Add("webGameTiengViet1Bai44Trang100|game-tiengviet-1-bai-44-trang-100.html|~/web_module/GameTiengViet1/Bai44/web__TiengViet1_lesson44_page100.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 45
        list.Add("webGameTiengViet1Bai45Trang102|game-tiengviet-1-bai-45-trang-102.html|~/web_module/GameTiengViet1/Bai45/web__TiengViet1_lesson45_page102.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 46
        list.Add("webGameTiengViet1Bai46Trang105|game-tiengviet-1-bai-46-trang-105.html|~/web_module/GameTiengViet1/Bai46/web__TiengViet1_lesson46_page105.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 47
        list.Add("webGameTiengViet1Bai47Trang106|game-tiengviet-1-bai-47-trang-106.html|~/web_module/GameTiengViet1/Bai47/web__TiengViet1_lesson47_page106.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 48
        list.Add("webGameTiengViet1Bai48Trang108|game-tiengviet-1-bai-48-trang-108.html|~/web_module/GameTiengViet1/Bai48/web__TiengViet1_lesson48_page108.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 49
        list.Add("webGameTiengViet1Bai49Trang110|game-tiengviet-1-bai-49-trang-110.html|~/web_module/GameTiengViet1/Bai49/web__TiengViet1_lesson49_page110.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 50
        list.Add("webGameTiengViet1Bai50Trang112|game-tiengviet-1-bai-50-trang-112.html|~/web_module/GameTiengViet1/Bai50/web_TiengViet1_Lesson50_page112.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 51
        list.Add("webGameTiengViet1Bai51Trang114|game-tiengviet-1-bai-51-trang-114.html|~/web_module/GameTiengViet1/Bai51/web_TiengViet1_Lesson51_page114.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 52
        list.Add("webGameTiengViet1Bai52Trang116|game-tiengviet-1-bai-52-trang-116.html|~/web_module/GameTiengViet1/Bai52/web__TiengViet1_lesson52_page116_117.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 53
        list.Add("webGameTiengViet1Bai53Trang118|game-tiengviet-1-bai-53-trang-118.html|~/web_module/GameTiengViet1/Bai53/web__TiengViet1_lesson53_page118_119.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 54
        list.Add("webGameTiengViet1Bai54Trang120|game-tiengviet-1-bai-54-trang-120.html|~/web_module/GameTiengViet1/Bai54/web__TiengViet1_Lesson54_page120_121.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 55
        list.Add("webGameTiengViet1Bai55Trang122|game-tiengviet-1-bai-55-trang-122.html|~/web_module/GameTiengViet1/Bai55/web__TiengViet1_Lesson55_page122_123.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 56
        list.Add("webGameTiengViet1Bai56Trang124|game-tiengviet-1-bai-56-trang-124.html|~/web_module/GameTiengViet1/Bai56/web__TiengViet1_Lesson56_page124_125.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 57
        list.Add("webGameTiengViet1Bai57Trang126|game-tiengviet-1-bai-57-trang-126.html|~/web_module/GameTiengViet1/Bai57/web__TiengViet1_Lesson57_page126_127.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 58
        list.Add("webGameTiengViet1Bai58Trang128|game-tiengviet-1-bai-58-trang-128.html|~/web_module/GameTiengViet1/Bai58/web__TiengViet1_lesson58_page128.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 59
        list.Add("webGameTiengViet1Bai59Trang130|game-tiengviet-1-bai-59-trang-130.html|~/web_module/GameTiengViet1/Bai59/web__TiengViet1_lesson59_page130.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 60
        list.Add("webGameTiengViet1Bai60Trang132|game-tiengviet-1-bai-60-trang-132.html|~/web_module/GameTiengViet1/Bai60/web__TiengViet1_lesson60_page132.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 61
        list.Add("webGameTiengViet1Bai61Trang134|game-tiengviet-1-bai-61-trang-134.html|~/web_module/GameTiengViet1/Bai61/web__TiengViet1_lesson61_page134.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 62
        list.Add("webGameTiengViet1Bai62Trang136|game-tiengviet-1-bai-62-trang-136.html|~/web_module/GameTiengViet1/Bai62/web__TiengViet1_lesson62_page136.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 63
        list.Add("webGameTiengViet1Bai63Trang138|game-tiengviet-1-bai-63-trang-138.html|~/web_module/GameTiengViet1/Bai63/web__TiengViet1_lesson63_page138.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 64
        list.Add("webGameTiengViet1Bai64Trang140|game-tiengviet-1-bai-64-trang-140.html|~/web_module/GameTiengViet1/Bai64/web__TiengViet1_lesson64_page140.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 65
        list.Add("webGameTiengViet1Bai63Trang142|game-tiengviet-1-bai-65-trang-142.html|~/web_module/GameTiengViet1/Bai65/web__TiengViet1_lesson65_page142.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 66
        list.Add("webGameTiengViet1Bai66Trang144|game-tiengviet-1-bai-66-trang-144.html|~/web_module/GameTiengViet1/Bai66/web_TiengViet1_Lesson66_page144.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 67
        list.Add("webGameTiengViet1Bai67Trang146|game-tiengviet-1-bai-67-trang-146.html|~/web_module/GameTiengViet1/Bai67/web_TiengViet1_Lesson67_page146.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 70
        list.Add("webGameTiengViet1Bai70Trang152|game-tiengviet-1-bai-70-trang-152.html|~/web_module/GameTiengViet1/Bai70/web__TiengViet1_lesson70_page152_153.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 71
        list.Add("webGameTiengViet1Bai71Trang154|game-tiengviet-1-bai-71-trang-154.html|~/web_module/GameTiengViet1/Bai71/web__TiengViet1_lesson71_page154_155.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 72
        list.Add("webGameTiengViet1Bai72Trang156|game-tiengviet-1-bai-72-trang-156.html|~/web_module/GameTiengViet1/Bai72/web__TiengViet1_Lesson72_page156_157.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 73
        list.Add("webGameTiengViet1Bai73Trang158|game-tiengviet-1-bai-73-trang-158.html|~/web_module/GameTiengViet1/Bai73/web__TiengViet1_Lesson73_page158_159.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 74
        list.Add("webGameTiengViet1Bai74Trang160|game-tiengviet-1-bai-74-trang-160.html|~/web_module/GameTiengViet1/Bai74/web__TiengViet1_Lesson74_page160_161.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 75
        list.Add("webGameTiengViet1Bai75Trang162|game-tiengviet-1-bai-75-trang-162.html|~/web_module/GameTiengViet1/Bai75/web__TiengViet1_Lesson75_page162_163.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 76
        list.Add("webGameTiengViet1Bai76Trang164|game-tiengviet-1-bai-76-trang-164.html|~/web_module/GameTiengViet1/Bai76/web__TiengViet1_lesson76_page164.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 77
        list.Add("webGameTiengViet1Bai77Trang166|game-tiengviet-1-bai-77-trang-166.html|~/web_module/GameTiengViet1/Bai77/web__TiengViet1_lesson77_page166.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 78
        list.Add("webGameTiengViet1Bai78Trang168|game-tiengviet-1-bai-78-trang-168.html|~/web_module/GameTiengViet1/Bai78/web__TiengViet1_lesson78_page168.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 79
        list.Add("webGameTiengViet1Bai79Trang170|game-tiengviet-1-bai-79-trang-170.html|~/web_module/GameTiengViet1/Bai79/web__TiengViet1_lesson79_page170.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 80
        list.Add("webGameTiengViet1Bai80Trang172|game-tiengviet-1-bai-80-trang-172.html|~/web_module/GameTiengViet1/Bai80/web__TiengViet1_lesson80_page172.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 81
        list.Add("webGameTiengViet1Bai81Trang174|game-tiengviet-1-bai-81-trang-174.html|~/web_module/GameTiengViet1/Bai81/web__TiengViet1_lesson81_page174.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 82
        list.Add("webGameTiengViet1Bai82Trang176|game-tiengviet-1-bai-82-trang-176.html|~/web_module/GameTiengViet1/Bai82/web__TiengViet1_lesson82_page176.aspx");
        //list game trắc nghiệm tiếng việt tập 1 bài 83
        list.Add("webGameTiengViet1Bai83Trang178|game-tiengviet-1-bai-83-trang-178.html|~/web_module/GameTiengViet1/Bai83/web__TiengViet1_lesson83_page178.aspx");
        //Trắc Nghiệm
        //list game trắc nghiệm tiếng việt tập 1 bài 68
        list.Add("webGameTiengViet1Bai68Trang148|game-tiengviet-1-bai-68-trang-148.html|~/web_module/GameTiengViet1/Bai68/web__TiengViet1_lesson68_page148.aspx");
        //Trắc Nghiệm
        //list game trắc nghiệm tiếng việt tập 1 bài 67
        list.Add("webGameTiengViet1Bai69Trang150|game-tiengviet-1-bai-69-trang-150.html|~/web_module/GameTiengViet1/Bai69/web__TiengViet1_lesson69_page150.aspx");
        //Trắc Nghiệm
        list.Add("webTracNghiem|bai-kiem-tra-{id_khoi}/{id_mon}.html|~/web_module/web_TracNghiem.aspx");
        //luyện tập
        list.Add("webLuyenTapTracNghiem|bai-luyen-tap/{id_khoi}/{id_mon}.html|~/web_module/web_LuyenTap.aspx");
        //Trắc Nghiệm Details
        list.Add("webBaiKiemTraDetals|bai-kiem-tra-{id_khoi}/bai-kiem-tra-chi-tiet/{title}-{id_test}.html|~/web_module/web_TracNghiemDetails.aspx");
        //Trắc Nghiệm Details Listening
        list.Add("webBaiKiemTraDetalsListening|bai-kiem-tra-listening-{id_khoi}/bai-kiem-tra-chi-tiet/{title}/{id_test}.html|~/web_module/web_TracNghiemDetails_Listening.aspx");
        //Trắc Nghiệm Writing
        list.Add("webBaiKiemTraDetalsWriting|bai-kiem-tra-writing-{id_khoi}/bai-kiem-tra-chi-tiet/{title}/{id_test}.html|~/web_module/web_TracNghiemDetails_Writing.aspx");
        //Trắc nghiệm reading
        list.Add("webBaiKiemTraReading|bai-kiem-tra-reading-{id_khoi}/bai-kiem-tra-chi-tiet/{title}/{id_test}.html|~/web_module/web_TracNghiemReading.aspx");
        //Đề Kiểm Tra Speaking
        list.Add("webBaiKiemTraSpeaking|bai-kiem-tra-speaking-{id_khoi}/bai-kiem-tra-chi-tiet/{title}/{id_test}.html|~/web_module/web_TracNghiemSpeaking.aspx");//Đề Kiểm Tra Speaking
        //Đề Kiểm Tra Reading+Writing A2
        list.Add("webBaiKiemTraReadingWriting|kiem-tra-a2/bai-kiem-tra-reading-writing-{id_khoi}/{id_test}.html|~/web_module/web_TracNghiemReadingWriting_A2.aspx");//Đề Kiểm Tra Reading+Writing A2
        //Đề Kiểm Tra Listening A2
        list.Add("webBaiKiemTraListening|kiem-tra-a2/bai-kiem-tra-listening-{id_khoi}/{id_test}.html|~/web_module/web_TracNghiemListening_A2.aspx");
        //Đề kiểm tra Speaking A2
        list.Add("webBaiKiemTraSpeakingA2|kiem-tra-a2/bai-kiem-tra-speaking-{id_khoi}/{id_test}.html|~/web_module/web_TracNghiemSpeaking_A2.aspx");
        //luyện tập details
        list.Add("webBaiLuyenTapDetals|bai-luyen-tap-chi-tiet-{id_khoi}/{name}-{id_test}.html|~/web_module/web_LuyenTapDetails.aspx");

        list.Add("webBaiLuyenTapMaTranDe|truy-cap-bai-luyen-tap-chi-tiet-{id_khoi}-{user_id}/{name}-{id_test}|~/web_module/MaTran_DeThi/web_MaTranDeThi_Detail_Version2.aspx");
        //list.Add("webBaiLuyenTapDetalsAccess|truy-cap-bai-luyen-tap-chi-tiet-{id_khoi}-{user_id}/{name}-{id_test}|~/web_module/web_LuyenTapDetails.aspx");
        //kết quả kiểm tra
        list.Add("webResultTest|ket-qua-bai-kiem-tra.html|~/web_module/web_BangDiem.aspx");
        list.Add("webResultLuyentap|ket-qua-bai-luyen-tap.html|~/web_module/web_KetQuaLuyenTap.aspx");
        list.Add("webbaikiemtratienganh|bai-kiem-tra-b1-{chapter_id}|~/web_module/web_TracNghiemListTest.aspx");


        //Môn học theo khối
        list.Add("webmonhoctheokhoi|mon-hoc-theo-khoi-{id_khoi}|~/web_module/web_ListMonHocTheoKhoi.aspx");
       


        return list;

    }
}