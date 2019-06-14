var gulp = require('gulp');
var sass = require('gulp-sass');
var concat = require('gulp-concat');
var image_min = require('gulp-imagemin');
var html_replace = require('gulp-html-replace');
var html_min = require('gulp-htmlmin');
var clean = require('gulp-clean');
var minify = require('gulp-minify');
var clean_css = require('gulp-clean-css');
var purify_css = require('gulp-purifycss');
var gzip = require('gulp-gzip');
var browser_sync = require('browser-sync');

gulp.task('sass', function () {
    return gulp.src([ 'node_modules/bootstrap/scss/bootstrap.scss',
    'src/scss/*.scss'])
        .pipe(sass())
        .pipe(concat('styles.css'))
        .pipe(purify_css(['src/js/*.js',
            'Pages/Shared/*.cshtml',
            'Pages/Accounts/*.cshtml']))
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('js', function () {
    return gulp.src(['node_modules/jquery/dist/jquery.min.js',
    'node_modules/bootstrap/js/dist/util.js', 
    'node_modules/bootstrap/js/dist/alert.js', 
    'node_modules/jquery-validation/dist/jquery.validate.min.js',
    'src/js/scripts.js'])
    .pipe(concat('bundle.js'))
        .pipe(gulp.dest('wwwroot/js'));
});

gulp.task('img', function () {
    return gulp.src(['src/img/**/*'])
        .pipe(gulp.dest('wwwroot/img'));
});
gulp.task('moveFiles', function(){
    return gulp.src(['src/favicon.ico','src/manifest.json'])
        .pipe(gulp.dest('wwwroot/'));
});

gulp.task('minifyCss', function () {
    return gulp.src(['wwwroot/css/styles.css'])
        .pipe(concat('styles.min.css'))
        .pipe(purify_css(['wwwroot/js/bundle.js',
            'Pages/Shared/*.cshtml',
            'Pages/Accounts/*.cshtml'
            ]))
        .pipe(clean_css())
        .pipe(gulp.dest('wwwroot/css'))
        .pipe(browser_sync.stream());
});
gulp.task('minifyJs', function () {
    return gulp.src(['wwwroot/js/bundle.js'])
        .pipe(concat('bundle.min.js'))
        .pipe(minify())
        .pipe(gulp.dest('wwwroot/js'))
        .pipe(browser_sync.stream());
});

gulp.task('minifyImg', function () {
    return gulp.src(['wwwroot/img/**/*'])
        .pipe(image_min())
        .pipe(gulp.dest('wwwroot/img'));
});
gulp.task('zip', function(callback){
    return zipFiles(callback);
});

gulp.task('clean', function () {
    return gulp.src(['src/css', 'wwwroot/'], {
        read: false,
        allowEmpty: true // to avoid errors when files/folders don't exist
    }).pipe(clean());
});
gulp.task('clean-dev', function () {
    return gulp.src(['wwwroot/css/styles.css', 'wwwrootst/js/bundle.js'], {
        read: false,
        allowEmpty: true // to avoid errors when files/folders don't exist
    }).pipe(clean());
});
gulp.task('prepare', gulp.parallel(['js', 'sass','moveFiles', 'img']));
gulp.task('minify', gulp.parallel(['minifyJs', 'minifyCss', 'minifyImg']));
gulp.task('watch', runWatchers);
//gulp.task('start', startServer);
//gulp.task('start-and-watch', function () {
//    startServer();
//    runWatchers();
//    gulp.watch(['src/scss/*', 'src/js/*']).on('change', browser_sync.reload);
//});

function runWatchers() {
    gulp.watch('src/scss/*', gulp.series(['sass', 'minifyCss']));
    gulp.watch('src/js/*', gulp.series(['js', 'minifyJs']));
    gulp.watch('src/img/*', gulp.series(['img', 'minifyImg']));
    gulp.watch('gulpfile.js', gulp.series(['clean', 'prepare', 'minify']));
}

function startServer() {
    browser_sync.init({
        server: 'wwwroot'
    });
}

function zipFiles(callback){
    gulp.src(['wwwroot/css/*.min.css'])
    .pipe(gzip())
        .pipe(gulp.dest('wwwroot/css'));

    gulp.src(['wwwroot/js/*.min.js'])
    .pipe(gzip())
        .pipe(gulp.dest('wwwroot/js'));

    gulp.src(['wwwroot/img/*'])
    .pipe(gzip())
        .pipe(gulp.dest('wwwroot/img'));

    callback();
}

gulp.task('generate-service-worker', function(callback) {
    var swPrecache = require('sw-precache');
    var rootDir = 'wwwroot';
  
    swPrecache.write(`${rootDir}/service-worker.js`, {
      staticFileGlobs: [rootDir + '/**/*.{js,html,css,png,jpg,gif,svg,eot,ttf,woff}'],
      stripPrefix: rootDir
    }, callback);
  });