using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sol_TagHelper_Movie_Cart.Models;
using Sol_TagHelper_Movie_Cart.Repository;
using Sol_TagHelper_Movie_Cart.ViewModel;

namespace Sol_TagHelper_Movie_Cart.Controllers
{
    public class MovieController : Controller
    {
        #region Declaration
        private readonly IMovieRepository movieRepository = null;
        #endregion 

        #region Constructor
        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
            this.MovieVM = new MovieViewModel();
        }
        #endregion 

        #region Property
        [BindProperty]
        public MovieViewModel MovieVM { get; set; }
        #endregion 

        #region Action
        public async  Task<IActionResult> Index()
        {
            //MovieVM.MovieList = await movieRepository.GetMovieDataAsync() as List<MovieModel>;
            MovieVM.MovieList = (await movieRepository.GetMovieDataAsync()).ToList();

            return View(MovieVM);
        }
        #endregion 
    }
}