using System.Collections.Generic;
using CKAN.ConsoleUI.Toolkit;
using CKAN.Games;

namespace CKAN.ConsoleUI {

    /// <summary>
    /// Screen for creating a new Repository entry
    /// </summary>
    public class RepoAddScreen : RepoScreen {

        /// <summary>
        /// Construct the screen
        /// </summary>
        /// <param name="theme">The visual theme to use to draw the dialog</param>
        /// <param name="game">Game from which to get repos</param>
        /// <param name="reps">Collection of Repository objects</param>
        /// <param name="userAgent">HTTP useragent string to use</param>
        public RepoAddScreen(ConsoleTheme                         theme,
                             IGame                                game,
                             SortedDictionary<string, Repository> reps,
                             string?                              userAgent)
            : base(theme, game, reps, "", "", userAgent) { }

        /// <summary>
        /// Check whether the fields are valid
        /// </summary>
        /// <returns>
        /// True if name and URL are valid, false otherwise.
        /// </returns>
        protected override bool Valid()
            => nameValid() && urlValid();

        /// <summary>
        /// Save the new Repository
        /// </summary>
        protected override void Save()
        {
            // Set priority to end of list
            int prio = 0;
            foreach (var kvp in editList) {
                Repository r = kvp.Value;
                if (r.priority >= prio) {
                    prio = r.priority + 1;
                }
            }
            editList.Add(name.Value, new Repository(name.Value, url.Value, prio));
        }

    }

}
