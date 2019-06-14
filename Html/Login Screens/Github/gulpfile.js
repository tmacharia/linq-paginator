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
    // .pipe(source_maps.init())
        .pipe(sass())
        .pipe(concat('styles.css'))
        .pipe(purify_css(['src/js/*.js','src/*.html']))
        // .pipe(source_maps.write('.'))
        .pipe(gulp.dest('dist/css'));
});

gulp.task('js', function () {
    return gulp.src(['node_modules/jquery/dist/jquery.min.js',
    'node_modules/bootstrap/js/dist/util.js', 
    'node_modules/bootstrap/js/dist/alert.js', 
    'node_modules/jquery-validation/dist/jquery.validate.min.js',
    'src/js/scripts.js'])
    // .pipe(source_maps.init())
    .pipe(concat('bundle.js'))
    // .pipe(source_maps.write('.'))
    .pipe(gulp.dest('dist/js'));
});

gulp.task('img', function () {
    return gulp.src(['src/img/**/*'])
        .pipe(gulp.dest('dist/img'))
});
gulp.task('moveFiles', function(){
    return gulp.src(['src/favicon.ico','src/manifest.json'])
        .pipe(gulp.dest('dist/'));
});
gulp.task('html', function () {
    return gulp.src('src/*.html')
        .pipe(html_replace({
            'css': 'css/styles.min.css',
            'js': 'js/bundle.min.js'
        }))
        .pipe(gulp.dest('dist'));
});
gulp.task('minifyCss', function () {
    return gulp.src(['dist/css/styles.css'])
    // .pipe(source_maps.init())
    
        .pipe(concat('styles.min.css'))
        .pipe(purify_css(['dist/js/bundle.js','dist/*.html']))
        .pipe(clean_css())
        // .pipe(source_maps.write('.'))
        .pipe(gulp.dest('dist/css'))
        .pipe(browser_sync.stream());
});
gulp.task('minifyJs', function () {
    return gulp.src(['dist/js/bundle.js'])
    // .pipe(source_maps.init())
        .pipe(concat('bundle.min.js'))
        .pipe(minify())
        // .pipe(source_maps.write('.'))
        .pipe(gulp.dest('dist/js'))
        .pipe(browser_sync.stream());
});
gulp.task('minifyHtml', () => {
    return gulp.src('dist/*.html')
        .pipe(html_min({
            collapseWhitespace: true
        }))
        .pipe(gulp.dest('dist'))
        .pipe(browser_sync.stream());
});
gulp.task('minifyImg', function () {
    return gulp.src(['dist/img/*'])
        .pipe(image_min())
        .pipe(gulp.dest('dist/img'))
});
gulp.task('zip', function(callback){
    return zipFiles(callback);
});

gulp.task('clean', function () {
    return gulp.src(['src/css', 'dist/'], {
        read: false,
        allowEmpty: true // to avoid errors when files/folders don't exist
    }).pipe(clean());
});
gulp.task('clean-dev', function(){
    return gulp.src(['dist/css/styles.css', 'dist/js/bundle.js'], {
        read: false,
        allowEmpty: true // to avoid errors when files/folders don't exist
    }).pipe(clean());
})
gulp.task('prepare', gulp.parallel(['js', 'sass', 'html','moveFiles', 'img']));
gulp.task('minify', gulp.parallel(['minifyJs', 'minifyCss', 'minifyHtml', 'minifyImg']));
gulp.task('watch', runWatchers);
gulp.task('start', startServer);
gulp.task('start-and-watch', function () {
    startServer();
    runWatchers();
    gulp.watch(['src/scss/*', 'src/js/*', 'src/*.html']).on('change', browser_sync.reload);
});

function runWatchers() {
    gulp.watch('src/scss/*', gulp.series(['sass', 'minifyCss']));
    gulp.watch('src/js/*', gulp.series(['js', 'minifyJs']));
    gulp.watch('src/img/*', gulp.series(['img', 'minifyImg']));
    gulp.watch('src/*.html', gulp.series(['html', 'minifyHtml']));
}

function startServer() {
    browser_sync.init({
        server: 'dist'
    });
}

function zipFiles(callback){
    gulp.src(['dist/css/*.min.css'])
    .pipe(gzip())
    .pipe(gulp.dest('dist/css'));

    gulp.src(['dist/js/*.min.js'])
    .pipe(concat('bundle.mini.js'))
    .pipe(gzip())
    .pipe(gulp.dest('dist/js'));

    gulp.src(['dist/*.html'])
    .pipe(gzip())
    .pipe(gulp.dest('dist/'));

    gulp.src(['dist/img/*'])
    .pipe(gzip())
    .pipe(gulp.dest('dist/img'));

    callback();
}

gulp.task('generate-service-worker', function(callback) {
    var swPrecache = require('sw-precache');
    var rootDir = 'dist';
  
    swPrecache.write(`${rootDir}/service-worker.js`, {
      staticFileGlobs: [rootDir + '/**/*.{js,html,css,png,jpg,gif,svg,eot,ttf,woff}'],
      stripPrefix: rootDir
    }, callback);
  });