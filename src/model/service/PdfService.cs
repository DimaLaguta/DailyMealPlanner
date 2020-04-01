using System;
using System.Collections.Generic;
using System.Drawing;
using DailyMealPlanner.model.business;
using DailyMealPlanner.model.service;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;


namespace DailyMealPlanner.src.model.service
{
    class PdfService
    {
        private readonly MealTimeService mealTimeService = new MealTimeService();

        public PdfService()
        {
        }

        public void CreateSavePdf(UserInformation user, List<MealTime> mealTimes)
        {
            using (PdfDocument document = new PdfDocument())
            {
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;

                PdfFont font1 = new PdfStandardFont(PdfFontFamily.Helvetica, 40);
                PdfFont font2 = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                PdfFont font3 = new PdfTrueTypeFont(new Font("Arial Unicode MS", 15), true);

                graphics.DrawString("Daily Food Ration", font1, PdfBrushes.DarkRed, new PointF(0, 0));
                PdfBitmap image = new PdfBitmap("ImageForPDF.jpg");
                graphics.DrawImage(image, 250, 70);
                PdfPen pdfPen = new PdfPen(Color.DarkBlue, 2);
                graphics.DrawLine(pdfPen, 0, 180, 600, 180);
                graphics.DrawString("User Data", font2, PdfBrushes.DarkSlateBlue, new PointF(0, 195));
                graphics.DrawString("Weight: " + user.Weight, font3, PdfBrushes.Black, new PointF(0, 220));
                graphics.DrawString("Height: " + user.Height, font3, PdfBrushes.Black, new PointF(0, 240));
                graphics.DrawString("Age: " + user.Age, font3, PdfBrushes.Black, new PointF(0, 260));
                graphics.DrawString("ARM: " + user.Arm, font3, PdfBrushes.Black, new PointF(300, 220));
                graphics.DrawString("BMR: " + user.Bmr, font3, PdfBrushes.Black, new PointF(300, 240));
                graphics.DrawString("Daily Calories Rate: " + (int) Math.Round(user.Bmr * user.Arm), font3, 
                    PdfBrushes.Black, new PointF(300, 260));
                graphics.DrawLine(pdfPen, 0, 310, 600, 310);
                graphics.DrawString("MealTimes", font2, PdfBrushes.DarkSlateBlue, new PointF(0, 320));

                int height = 360;

                for (int i = 0; i < mealTimes.Count; i++)
                {
                    height = height + 10;
                    graphics.DrawString(mealTimes[i].Time.Name, font3, PdfBrushes.PaleVioletRed, new PointF(0, height));
                    for (int j = 0; j < mealTimes[i].Products.Count; j++)
                    {
                        height = height + 20;
                        graphics.DrawString(
                            mealTimes[i].Products[j].Name + ": " + mealTimes[i].Products[j].Gramms + " грамм", font3,
                            PdfBrushes.Black, new PointF(0, height));
                    }
                    height = height + 20;
                }
                graphics.DrawLine(pdfPen, 0, height + 20, 600, height + 20);
                graphics.DrawString("Total: " + mealTimeService.CalculateCaloriesPerDay() + " calories", font2,
                    PdfBrushes.PaleVioletRed, new PointF(0, height + 40));

                document.Save("DailyFoodRation.pdf");
                document.Close(true);
            }
        }
    }
}