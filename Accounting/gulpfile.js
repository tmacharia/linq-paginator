var gulp = require('gulp');
var del = require('del');
var auto_prefixer = require('gulp-autoprefixer');
var csso = require('gulp-csso');
var sass = require('gulp-sass');


// Set the browser that you want to support
const AUTOPREFIXER_BROWSERS = [
    'ie >= 10',
    'ie_mob >= 10',
    'ff >= 30',
    'chrome >= 34',
    'safari >= 7',
    'opera >= 23',
    'ios >= 7',
    'android >= 4.4',
    'bb >= 10'
];

gulp.task('sass', function () {
    return gulp.src(['Assets/scss/*.scss'])
        .pipe(sass())
        .pipe(gulp.dest('Assets/css'));
});

gulp.task('minify', function () {
    return gulp.src(['Assets/css/*.css'])
        // auto-prefix styles for cross browser compatibility
        .pipe(auto_prefixer({ browsers: AUTOPREFIXER_BROWSERS }))
        // minify styles
        .pipe(csso())
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('watch', function () {
    gulp.watch('Assets/scss/*.scss', gulp.series(['sass','minify']));
    // Other watchers
});

gulp.task('clean', function () {
    return del.sync(['Assets/css', 'Assets/js', 'wwwroot/css', 'wwwroot/js']);
});