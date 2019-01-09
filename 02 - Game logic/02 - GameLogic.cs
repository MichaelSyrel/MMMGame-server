using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MMMGame
{
    public class GameLogic
    {
        public ModelConverter converter = new ModelConverter();
   
        private DAL dal = new DAL();



        public ImageModel[][] GetGameRoundData(int difficulty)
        {
            //Step  1: Create the game board based on the difficulty we got from the client.
            //1 - easy, 8 images.
            //2 - medium, 10 images.
            //3 - hard, 12 images.
            ImageModel[][] gameBoard = InitializeGameBoard(difficulty);

            //step 2: Get the appropriate number of images according to the difficulty value entered.
            int imageAmount = (difficulty * 2 + 6);
            List<Image> thisRoundImages = getImages(imageAmount);

            //step 3: Set the images data inside each image.
            List<ImageModel> images = converter.ImageListToImageModel(thisRoundImages);
            gameBoard = SetRound(images, gameBoard);

            return gameBoard;
        }

        public ImageModel[][] SetRound(List<ImageModel> images, ImageModel[][] gameBoard)
        {
            Random rnd = new Random();

            int imageAmount = images.Count() * 2;
            int row;
            int column;
            int chosenCell;
           
            for (int i = 0; i < images.Count(); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    do
                    {
                        chosenCell = rnd.Next(0, imageAmount);
                        row = chosenCell / (images.Count() / 2);
                        column = chosenCell % (images.Count() / 2);
                    } while (gameBoard[row][column].id != -1);
                   
                    images[i].currentClass = "base";
                    gameBoard[row][column] = images[i];
                }
            }
            return gameBoard;
        }

        public List<Image> getImages(int imageAmount)
        {

            List<Image> allAvailableImages = dal.GetImages();

            List<Image> chosenImages = new List<Image>();

            Image imageToCheck = new Image();

            Random rnd = new Random();

            int lastImageId = allAvailableImages.OrderByDescending(x => x.ID).Take(1).ToList().FirstOrDefault().ID;
            int r;
            while (chosenImages.Count() < imageAmount)
            {
                r = Convert.ToInt32(rnd.Next(0, lastImageId));
                imageToCheck = allAvailableImages.Where(img => img.ID == r).SingleOrDefault();

                if (imageToCheck != null)
                {
                    if (chosenImages.Where(img => img.ID == imageToCheck.ID).Count() == 0)
                    {
                        chosenImages.Add(imageToCheck);
                    }
                }

            }

            return chosenImages;

        }

        public ImageModel[][] InitializeGameBoard(int difficulty)
        {

            //difficulty 1 is 4*4 - 8 images * 2 total 16 
            //difficulty 2 is 5*4 - 10 images * 2 total 20 
            //difficulty 3 is 6*4 - 12 images * 2 total 24



            ImageModel[][] gameBoard = new ImageModel[4][];
            for (int i = 0; i < 4; i++)
            {
                gameBoard[i] = new ImageModel[difficulty + 3];
                for (int j = 0; j < (difficulty + 3); j++)
                {
                    gameBoard[i][j] = new ImageModel
                    {
                        id = -1
                    };
                }
            }


            return gameBoard;
        }

        public ResultModel[] GetResults()
        {
            List<Result> resultList = dal.GetResults();
            List<ResultModel> results = converter.ResultsToResultModelList(resultList);
            return results.ToArray();
        }

        public ResultModel PostResult(ResultModel result)
        {
            result.date = DateTime.Now;
            Result newRes = converter.ToResult(result);
            dal.AddResult(newRes);

            return result;
        }
    }
}
