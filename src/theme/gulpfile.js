const gulp = require('gulp');
const tailwindConfig = "tailwind.config.js"; 
const mainCSS = "Styles/lucavice.css"; 
var argv = require('yargs').argv;

var prod = (argv.prod === undefined) ? false : true;

gulp.task("css", function () {
    const atimport = require("postcss-import");
    const postcss = require("gulp-postcss");
    const tailwindcss = require("tailwindcss");
    const purgecss = require("gulp-purgecss");
    const autoprefixer = require('gulp-autoprefixer');
    const cleanCSS = require('gulp-clean-css');

    let task = gulp
    .src(mainCSS)
    .pipe(postcss([atimport(), tailwindcss(tailwindConfig)]));

    if (prod) {
      task = task.pipe(
        purgecss({
          content: ["**/*.liquid", "Styles/*.css"],
          defaultExtractor: content =>
            content.match(/[\w-/:]+(?<!:)/g) || []
        })
      )
      task = task.pipe(cleanCSS());
      task = task.pipe(autoprefixer({ cascade: false }));
    }

    return task.pipe(gulp.dest("wwwroot/assets/dist/css"));
});
