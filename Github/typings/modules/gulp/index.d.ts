// Generated by typings
// Source: https://raw.githubusercontent.com/types/npm-vinyl/13670eff75aba7b4c95546ec9eebbb72e3537188/index.d.ts
declare module '~gulp~vinyl-fs~vinyl/index' {

import * as fs from 'fs';

namespace File {
    export interface FileOptions {

        /**
         * Default: process.cwd()
         */
        cwd?: string;

        /**
         * Used for relative pathing. Typically where a glob starts.
         */
        base?: string;

        /**
         * Full path to the file.
         */
        path?: string;

        /**
         * Path history. Has no effect if options.path is passed.
         */
        history?: string[];

        /**
         * The result of an fs.stat call. See fs.Stats for more information.
         */
        stat?: fs.Stats;

        /**
         * File contents.
         * Type: Buffer, Stream, or null
         */
        contents?: Buffer | NodeJS.ReadWriteStream;
    }

    export interface PipeOptions {
        /**
         * If false, the destination stream will not be ended (same as node core).
         */
        end?: boolean;
    }
}

/**
 * A virtual file format.
 */
class File {
    constructor(options?: File.FileOptions);

    /**
     * Default: process.cwd()
     */
    public cwd: string;

    /**
     * Used for relative pathing. Typically where a glob starts.
     */
    public dirname: string;
    public basename: string;
    public base: string;

    /**
     * Full path to the file.
     */
    public path: string;
    public stat: fs.Stats;

    /**
     * Gets and sets stem (filename without suffix) for the file path.
     */
    public stem: string;

    /**
     * Gets and sets path.extname for the file path
     */
    public extname: string;

    /**
     * Array of path values the file object has had
     */
    public history: string[];

    /**
     * Type: Buffer|Stream|null (Default: null)
     */
    public contents: Buffer | NodeJS.ReadableStream;

    /**
     * Returns path.relative for the file base and file path.
     * Example:
     *  var file = new File({
     *    cwd: "/",
     *    base: "/test/",
     *    path: "/test/file.js"
     *  });
     *  console.log(file.relative); // file.js
     */
    public relative: string;

    /**
     * Returns true if file.contents is a Buffer.
     */
    public isBuffer(): boolean;

    /**
     * Returns true if file.contents is a Stream.
     */
    public isStream(): boolean;

    /**
     * Returns true if file.contents is null.
     */
    public isNull(): boolean;

    /**
     * Returns a new File object with all attributes cloned. Custom attributes are deep-cloned.
     */
    public clone(opts?: { contents?: boolean, deep?: boolean }): File;

    /**
     * If file.contents is a Buffer, it will write it to the stream.
     * If file.contents is a Stream, it will pipe it to the stream.
     * If file.contents is null, it will do nothing.
     */
    public pipe<T extends NodeJS.ReadWriteStream>(stream: T, opts?: File.PipeOptions): T;

    /**
     * Returns a pretty String interpretation of the File. Useful for console.log.
     */
    public inspect(): string;

    /**
     * Checks if a given object is a vinyl file.
     */
    public static isVinyl(obj: any): boolean;
}

export = File;
}

// Generated by typings
// Source: https://raw.githubusercontent.com/typed-typings/npm-minimatch/74f47de8acb42d668491987fc6bc144e7d9aa891/minimatch.d.ts
declare module '~gulp~vinyl-fs~glob-stream~glob~minimatch/minimatch' {
function minimatch (target: string, pattern: string, options?: minimatch.Options): boolean;

namespace minimatch {
	export function match (list: string[], pattern: string, options?: Options): string[];
	export function filter (pattern: string, options?: Options): (element: string, indexed: number, array: string[]) => boolean;
	export function makeRe (pattern: string, options?: Options): RegExp;

  /**
   * All options are `false` by default.
   */
	export interface Options {
    /**
     * Dump a ton of stuff to stderr.
     */
		debug?: boolean;
    /**
     * Do not expand `{a,b}` and `{1..3}` brace sets.
     */
		nobrace?: boolean;
    /**
     * Disable `**` matching against multiple folder names.
     */
		noglobstar?: boolean;
    /**
     * Allow patterns to match filenames starting with a period, even if the pattern does not explicitly have a period in that spot.
     *
     * Note that by default, `a\/**\/b` will not match `a/.d/b`, unless `dot` is set.
     */
		dot?: boolean;
    /**
     * Disable "extglob" style patterns like `+(a|b)`.
     */
		noext?: boolean;
    /**
     * Perform a case-insensitive match.
     */
		nocase?: boolean;
    /**
     * When a match is not found by `minimatch.match`, return a list containing the pattern itself if this option is set. When not set, an empty list is returned if there are no matches.
     */
		nonull?: boolean;
    /**
     * If set, then patterns without slashes will be matched against the basename of the path if it contains slashes. For example, `a?b` would match the path `/xyz/123/acb`, but not `/xyz/acb/123`.
     */
		matchBase?: boolean;
    /**
     * Suppress the behavior of treating `#` at the start of a pattern as a comment.
     */
		nocomment?: boolean;
    /**
     * Suppress the behavior of treating a leading `!` character as negation.
     */
		nonegate?: boolean;
    /**
     * Returns from negate expressions the same as if they were not negated. (Ie, true on a hit, false on a miss.)
     */
		flipNegate?: boolean;
	}

	export class Minimatch {
		constructor (pattern: string, options?: Options);

    /**
     * The original pattern the minimatch object represents.
     */
    pattern: string;
    /**
     * The options supplied to the constructor.
     */
		options: Options;

    /**
     * Created by the `makeRe` method. A single regular expression expressing the entire pattern. This is useful in cases where you wish to use the pattern somewhat like `fnmatch(3)` with `FNM_PATH` enabled.
     */
		regexp: RegExp;
    /**
     * True if the pattern is negated.
     */
		negate: boolean;
    /**
     * True if the pattern is a comment.
     */
		comment: boolean;
    /**
     * True if the pattern is `""`.
     */
		empty: boolean;

    /**
     * Generate the regexp member if necessary, and return it. Will return false if the pattern is invalid.
     */
		makeRe (): RegExp | boolean;
    /**
     * Return true if the filename matches the pattern, or false otherwise.
     */
		match (fname: string): boolean;
    /**
     * Take a `/-`split filename, and match it against a single row in the `regExpSet`. This method is mainly for internal use, but is exposed so that it can be used by a glob-walker that needs to avoid excessive filesystem calls.
     */
		matchOne (fileArray: string[], patternArray: string[], partial: boolean): boolean;
	}
}

export = minimatch;
}

// Generated by typings
// Source: https://raw.githubusercontent.com/types/npm-glob/59ca0f5d4696a8d4da27858035316c1014133fcb/glob.d.ts
declare module '~gulp~vinyl-fs~glob-stream~glob/glob' {
import events = require('events');
import fs = require('fs');
import minimatch = require('~gulp~vinyl-fs~glob-stream~glob~minimatch/minimatch');

function glob (pattern: string, cb: (err: Error, matches: string[]) => void): void;
function glob (pattern: string, options: glob.Options, cb: (err: Error, matches: string[]) => void): void;

namespace glob {
  export function sync (pattern: string, options?: Options): string[];
  export function hasMagic (pattern: string, options?: Options): boolean;

  export interface Cache {
    [path: string]: boolean | string | string[];
  }

  export interface StatCache {
    [path: string]: fs.Stats;
  }

  export interface Symlinks {
    [path: string]: boolean;
  }

  export interface Options extends minimatch.Options {
    /**
     * The current working directory in which to search. Defaults to `process.cwd()`.
     */
    cwd?: string;
    /**
     * The place where patterns starting with `/` will be mounted onto. Defaults to `path.resolve(options.cwd, "/")` (`/` on Unix systems, and `C:\` or some such on Windows.)
     */
    root?: string;
    /**
     * Include `.dot` files in normal matches and `globstar` matches. Note that an explicit dot in a portion of the pattern will always match dot files.
     */
    dot?: boolean;
    /**
     * By default, a pattern starting with a forward-slash will be "mounted" onto the root setting, so that a valid filesystem path is returned. Set this flag to disable that behavior.
     */
    nomount?: boolean;
    /**
     * Add a `/` character to directory matches. Note that this requires additional stat calls.
     */
    mark?: boolean;
    /**
     * Don't sort the results.
     */
    nosort?: boolean;
    /**
     * Set to true to stat all results. This reduces performance somewhat, and is completely unnecessary, unless `readdir` is presumed to be an untrustworthy indicator of file existence.
     */
    stat?: boolean;
    /**
     * When an unusual error is encountered when attempting to read a directory, a warning will be printed to stderr. Set the `silent` option to true to suppress these warnings.
     */
    silent?: boolean;
    /**
     * When an unusual error is encountered when attempting to read a directory, the process will just continue on in search of other matches. Set the `strict` option to raise an error in these cases.
     */
    strict?: boolean;
    /**
     * See `cache` property above. Pass in a previously generated cache object to save some fs calls.
     */
    cache?: Cache;
    /**
     * A cache of results of filesystem information, to prevent unnecessary stat calls. While it should not normally be necessary to set this, you may pass the statCache from one glob() call to the options object of another, if you know that the filesystem will not change between calls. (See https://github.com/isaacs/node-glob#race-conditions)
     */
    statCache?: StatCache;
    /**
     * A cache of known symbolic links. You may pass in a previously generated `symlinks` object to save lstat calls when resolving `**` matches.
     */
    symlinks?: Symlinks;
    /**
     * DEPRECATED: use `glob.sync(pattern, opts)` instead.
     */
    sync?: boolean;
    /**
     * In some cases, brace-expanded patterns can result in the same file showing up multiple times in the result set. By default, this implementation prevents duplicates in the result set. Set this flag to disable that behavior.
     */
    nounique?: boolean;
    /**
     * Set to never return an empty set, instead returning a set containing the pattern itself. This is the default in glob(3).
     */
    nonull?: boolean;
    /**
     * Set to enable debug logging in minimatch and glob.
     */
    debug?: boolean;
    /**
     * Do not expand `{a,b}` and `{1..3}` brace sets.
     */
    nobrace?: boolean;
    /**
     * Do not match `**` against multiple filenames. (Ie, treat it as a normal `*` instead.)
     */
    noglobstar?: boolean;
    /**
     * Do not match `+(a|b)` "extglob" patterns.
     */
    noext?: boolean;
    /**
     * Perform a case-insensitive match. Note: on case-insensitive filesystems, non-magic patterns will match by default, since `stat` and `readdir` will not raise errors.
     */
    nocase?: boolean;
    /**
     * Perform a basename-only match if the pattern does not contain any slash characters. That is, `*.js` would be treated as equivalent to `**\/*.js`, matching all js files in all directories.
     */
    matchBase?: any;
    /**
     * Do not match directories, only files. (Note: to match only directories, simply put a `/` at the end of the pattern.)
     */
    nodir?: boolean;
    /**
     * Add a pattern or an array of glob patterns to exclude matches. Note: `ignore` patterns are always in `dot:true` mode, regardless of any other settings.
     */
    ignore?: string | string[];
    /**
     * Follow symlinked directories when expanding `**` patterns. Note that this can result in a lot of duplicate references in the presence of cyclic links.
     */
    follow?: boolean;
    /**
     * Set to true to call `fs.realpath` on all of the results. In the case of a symlink that cannot be resolved, the full absolute path to the matched entry is returned (though it will usually be a broken symlink)
     */
    realpath?: boolean;
  }

  export class Glob extends events.EventEmitter {
    constructor (pattern: string, cb?: (err: Error, matches: string[]) => void);
    constructor (pattern: string, options: Options, cb?: (err: Error, matches: string[]) => void);

    /**
     * The minimatch object that the glob uses.
     */
    minimatch: minimatch.Minimatch;
    /**
     * The options object passed in.
     */
    options: Options;
    /**
     * Boolean which is set to true when calling `abort()`. There is no way at this time to continue a glob search after aborting, but you can re-use the statCache to avoid having to duplicate syscalls.
     * @type {boolean}
     */
    aborted: boolean;
    /**
     * Convenience object.
     */
    cache: Cache;
    /**
     * Cache of `fs.stat` results, to prevent statting the same path multiple times.
     */
    statCache: StatCache;
    /**
     * A record of which paths are symbolic links, which is relevant in resolving `**` patterns.
     */
    symlinks: Symlinks;
    /**
     * An optional object which is passed to `fs.realpath` to minimize unnecessary syscalls. It is stored on the instantiated Glob object, and may be re-used.
     */
    realpathCache: { [path: string]: string };
    found: string[];

    /**
     * Temporarily stop the search.
     */
    pause(): void;
    /**
     * Resume the search.
     */
    resume(): void;
    /**
     * Stop the search forever.
     */
    abort(): void;
  }
}

export = glob;
}

// Generated by typings
// Source: https://raw.githubusercontent.com/types/npm-glob-stream/678827da5642c639d3e0c572d96211d278b1e87e/index.d.ts
declare module '~gulp~vinyl-fs~glob-stream/index' {

import glob = require('~gulp~vinyl-fs~glob-stream~glob/glob');

export interface Options extends glob.Options {
    cwd?: string;
    base?: string;
    cwdbase?: boolean;
}

export interface Element {
    cwd: string;
    base: string;
    path: string;
}

export function create(glob: string, opts?: Options): NodeJS.ReadableStream;
export function create(globs: string[], opts?: Options): NodeJS.ReadableStream;
}

// Generated by typings
// Source: https://raw.githubusercontent.com/types/npm-through2/83d47b72bdd67d6b94155846514a0e4212458d53/index.d.ts
declare module '~gulp~vinyl-fs~through2/index' {
// Type definitions for through2 v 2.0.0
// Project: https://github.com/rvagg/through2
// Original Definitions by: Bart van der Schoor <https://github.com/Bartvds>, jedmao <https://github.com/jedmao>, Georgios Valotasios <https://github.com/valotas>
// Definitions: https://github.com/borisyankov/DefinitelyTyped

import * as stream from 'stream';

function through2(transformFunction?: through2.TransformFunction, flushFunction?: through2.FlushCallback): NodeJS.ReadWriteStream;
function through2(options?: through2.Options, transformFunction?: through2.TransformFunction, flushFunction?: through2.FlushCallback): NodeJS.ReadWriteStream;

namespace through2 {

  export type TransformCallback = (err?: any, data?: any) => void;
  export type TransformFunction = (chunk: any, encoding: string, callback: TransformCallback) => void;
  export type FlushCallback = (flushCallback: () => void) => void;

  export interface Options extends stream.DuplexOptions {}

  export function ctor(options?: Options, transformFunction?: TransformFunction, flushFunction?: FlushCallback): NodeJS.ReadWriteStream;
  export function obj(transformFunction?: TransformFunction, flushFunction?: FlushCallback): NodeJS.ReadWriteStream;

  /**
   * Type of `this` inside TransformFunction and FlushCallback.
   */
  export interface This {
    push(data: any): void;
  }
}

export = through2;
}

// Generated by typings
// Source: https://raw.githubusercontent.com/types/npm-vinyl-fs/94022d746133d86138b21e97fdc4179a89645685/index.d.ts
declare module '~gulp~vinyl-fs/index' {

import File = require('~gulp~vinyl-fs~vinyl/index');
import * as globStream from '~gulp~vinyl-fs~glob-stream/index';
import * as through from '~gulp~vinyl-fs~through2/index';

interface SrcOptions extends globStream.Options, through.Options {

    /** Specifies the working directory the folder is relative to */
    cwd?: string;

    /**
     * Specifies the folder relative to the cwd
     * This is used to determine the file names when saving in .dest()
     * Default is where the glob begins
     */
    base?: string;

    /**
     * Setting this to false will make file.contents a paused stream
     * If true it will buffer the file contents
     * Defaults to true
     */
    buffer?: boolean;

    /**
     * Setting this to false will ignore the contents of the file and disable writing to disk to speed up operations
     * Defaults to true
     */
    read?: boolean;

    /**  Only find files that have been modified since the time specified */
    since?: Date | number;

    /**
     * Setting this to true will create a duplex stream, one that passes through items and emits globbed files.
     * Defaults to false
     */
    passthrough?: boolean;

    /**
     * Setting this to true will enable sourcemaps.
     * Defaults to false
     */
    sourcemaps?: boolean;
}

/**
 * Gets files that match the glob and converts them into the vinyl format
 * @param globs Takes a glob string or an array of glob strings as the first argument
 * Globs are executed in order, so negations should follow positive globs
 * fs.src(['!b*.js', '*.js']) would not exclude any files, but this would: fs.src(['*.js', '!b*.js'])
 * @param opt Options Vinyl source options, changes the way the files are read, found, or stored in the vinyl stream
 */
export function src(globs: string | string[], options?: SrcOptions): NodeJS.ReadWriteStream;

export interface DestOptions {
    /**
     * Specify the working directory the folder is relative to
     * Default is process.cwd()
     */
    cwd?: string;

    /**
     * Specify the mode the files should be created with
     * Default is the mode of the input file (file.stat.mode)
     * or the process mode if the input file has no mode property
     */
    mode?: number | string;

    /** Specify the mode the directory should be created with. Default is the process mode */
    dirMode?: number | string;

    /** Specify if existing files with the same path should be overwritten or not. Default is true, to always overwrite existing files */
    overwrite?: boolean;
}

/**
 * On write the stream will save the vinyl File to disk at the folder/cwd specified.
 * After writing the file to disk, it will be emitted from the stream so you can keep piping these around.
 * The file will be modified after being written to this stream:
 * cwd, base, and path will be overwritten to match the folder
 * stat.mode will be overwritten if you used a mode parameter
 * contents will have it's position reset to the beginning if it is a stream
 * @param folder destination folder
 */
export function dest(folder: string, options?: DestOptions): NodeJS.ReadWriteStream;

/**
 * On write the stream will save the vinyl File to disk at the folder/cwd specified.
 * After writing the file to disk, it will be emitted from the stream so you can keep piping these around.
 * The file will be modified after being written to this stream:
 * cwd, base, and path will be overwritten to match the folder
 * stat.mode will be overwritten if you used a mode parameter
 * contents will have it's position reset to the beginning if it is a stream
 * @param getFolderPath function that takes in a file and returns a folder path
 */
export function dest(getFolderPath: (file: File) => string): NodeJS.ReadWriteStream;

export interface SymlinkOptions {

    /**
     * Specify the working directory the folder is relative to
     * Default is process.cwd()
     */
    cwd?: string;

    /** Specify the mode the directory should be created with. Default is the process mode */
    mode?: number | string;

    /**
     * Specify the mode the directory should be created with
     * Default is the process mode
     */
    dirMode?: number;
}

/**
 * On write the stream will create a symbolic link (i.e. symlink) on disk at the folder/cwd specified.
 * After creating the symbolic link, it will be emitted from the stream so you can keep piping these around.
 * The file will be modified after being written to this stream:
 * cwd, base, and path will be overwritten to match the folder
 */
export function symlink(folder: string, opts?: SymlinkOptions): NodeJS.ReadWriteStream;

/**
 * On write the stream will create a symbolic link (i.e. symlink) on disk at the folder/cwd generated from getFolderPath.
 * After creating the symbolic link, it will be emitted from the stream so you can keep piping these around.
 * The file will be modified after being written to this stream:
 * cwd, base, and path will be overwritten to match the folder
 */
export function symlink(getFolderPath: (File: File) => string, opts?: SymlinkOptions): NodeJS.ReadWriteStream;
}

// Generated by typings
// Source: https://raw.githubusercontent.com/types/npm-chokidar/b60918f9b3b996a68f1ea27f192233475cfbbc22/index.d.ts
declare module '~gulp~chokidar/index' {

import * as fs from 'fs';
import {EventEmitter} from 'events';

/**
 * The object's keys are all the directories (using absolute paths unless the `cwd` option was
 * used), and the values are arrays of the names of the items contained in each directory.
 */
export interface WatchedPaths {
    [directory: string]: string[];
}

export class FSWatcher extends EventEmitter implements fs.FSWatcher {

    /**
     * Add files, directories, or glob patterns for tracking. Takes an array of strings or just one
     * string.
     */
    add(paths: string | string[]): void;

    /**
     * Stop watching files, directories, or glob patterns. Takes an array of strings or just one
     * string.
     */
    unwatch(paths: string | string[]): void;

    /**
     * Returns an object representing all the paths on the file system being watched by this
     * `FSWatcher` instance. The object's keys are all the directories (using absolute paths unless
     * the `cwd` option was used), and the values are arrays of the names of the items contained in
     * each directory.
     */
    getWatched(): WatchedPaths;

    /**
     * Removes all listeners from watched files.
     */
    close(): void;
}

export interface WatchOptions {

    /**
     * Indicates whether the process should continue to run as long as files are being watched. If
     * set to `false` when using `fsevents` to watch, no more events will be emitted after `ready`,
     * even if the process continues to run.
     */
    persistent?: boolean;

    /**
     * ([anymatch](https://github.com/es128/anymatch)-compatible definition) Defines files/paths to
     * be ignored. The whole relative or absolute path is tested, not just filename. If a function
     * with two arguments is provided, it gets called twice per path - once with a single argument
     * (the path), second time with two arguments (the path and the
     * [`fs.Stats`](http://nodejs.org/api/fs.html#fs_class_fs_stats) object of that path).
     */
    ignored?: any;

    /**
     * If set to `false` then `add`/`addDir` events are also emitted for matching paths while
     * instantiating the watching as chokidar discovers these file paths (before the `ready` event).
     */
    ignoreInitial?: boolean;

    /**
     * When `false`, only the symlinks themselves will be watched for changes instead of following
     * the link references and bubbling events through the link's path.
     */
    followSymlinks?: boolean;

    /**
     * The base directory from which watch `paths` are to be derived. Paths emitted with events will
     * be relative to this.
     */
    cwd?: string;

    /**
     * Whether to use fs.watchFile (backed by polling), or fs.watch. If polling leads to high CPU
     * utilization, consider setting this to `false`. It is typically necessary to **set this to
     * `true` to successfully watch files over a network**, and it may be necessary to successfully
     * watch files in other non-standard situations. Setting to `true` explicitly on OS X overrides
     * the `useFsEvents` default.
     */
    usePolling?: boolean;

    /**
     * Whether to use the `fsevents` watching interface if available. When set to `true` explicitly
     * and `fsevents` is available this supercedes the `usePolling` setting. When set to `false` on
     * OS X, `usePolling: true` becomes the default.
     */
    useFsEvents?: boolean;

    /**
     * If relying upon the [`fs.Stats`](http://nodejs.org/api/fs.html#fs_class_fs_stats) object that
     * may get passed with `add`, `addDir`, and `change` events, set this to `true` to ensure it is
     * provided even in cases where it wasn't already available from the underlying watch events.
     */
    alwaysStat?: boolean;

    /**
     * If set, limits how many levels of subdirectories will be traversed.
     */
    depth?: number;

    /**
     * Interval of file system polling.
     */
    interval?: number;

    /**
     * Interval of file system polling for binary files. ([see list of binary extensions](https://gi
     * thub.com/sindresorhus/binary-extensions/blob/master/binary-extensions.json))
     */
    binaryInterval?: number;

    /**
     *  Indicates whether to watch files that don't have read permissions if possible. If watching
     *  fails due to `EPERM` or `EACCES` with this set to `true`, the errors will be suppressed
     *  silently.
     */
    ignorePermissionErrors?: boolean;

    /**
     * `true` if `useFsEvents` and `usePolling` are `false`). Automatically filters out artifacts
     * that occur when using editors that use "atomic writes" instead of writing directly to the
     * source file. If a file is re-added within 100 ms of being deleted, Chokidar emits a `change`
     * event rather than `unlink` then `add`. If the default of 100 ms does not work well for you,
     * you can override it by setting `atomic` to a custom value, in milliseconds.
     */
    atomic?: boolean | number;

    /**
     * can be set to an object in order to adjust timing params:
     */
    awaitWriteFinish?: AwaitWriteFinishOptions;
}

export interface AwaitWriteFinishOptions {

    /**
     * Amount of time in milliseconds for a file size to remain constant before emitting its event.
     */
    stabilityThreshold?: number;

    /**
     * File size polling interval.
     */
    pollInterval?: number;
}

/**
 * produces an instance of `FSWatcher`.
 */
export function watch(paths: string | string[], options?: WatchOptions): FSWatcher;
}

// Generated by typings
// Source: https://raw.githubusercontent.com/types/npm-undertaker/7173e366378a4eb493f8921629e29ca0f84a50d3/index.d.ts
declare module '~gulp~undertaker/index' {

class Undertaker {

    /**
     * The constructor is used to create a new instance of `Undertaker`. Each instance of
     * `Undertaker` gets its own instance of a registry. By default, the registry is an instance of
     * [`undertaker-registry`][undertaker-registry] but it can be an instance of any other registry
     * that follows the [Custom Registries API][custom-registries].
     *
     * To use a custom registry, pass a custom registry instance (`new CustomRegistry([options])`)
     * when instantiating a new `Undertaker` instance. This will use the custom registry instance
     * for that `Undertaker` instance.
     */
    constructor(registry?: Undertaker.Registry);

    task: Undertaker.TaskMethod;
    /**
     * Takes a variable amount of strings (taskName) and/or functions (fn)
     * and returns a function of the composed tasks or functions.
     * Any taskNames are retrieved from the registry using the get method.
     *
     * When the returned function is executed, the tasks or functions will be executed in series,
     * each waiting for the prior to finish. If an error occurs, execution will stop.
     * @param task
     */
    series(...tasks: (string | Undertaker.Task)[]): Undertaker.Task;

    /**
     * Takes a variable amount of strings (taskName) and/or functions (fn)
     * and returns a function of the composed tasks or functions.
     * Any taskNames are retrieved from the registry using the get method.
     *
     * When the returned function is executed, the tasks or functions will be executed in parallel,
     * all being executed at the same time. If an error occurs, all execution will complete.
     * @param tasks
     */
    parallel(...tasks: (string | Undertaker.Task)[]): Undertaker.Task;

    /**
     * Returns the current registry object.
     */
    registry(): Undertaker.Registry;

    /**
     * The tasks from the current registry will be transferred to it
     * and the current registry will be replaced with the new registry.
     * @param registry
     */
    registry(registry: Undertaker.Registry): void;

    /**
     * Optionally takes an object (options) and returns an object representing the tree of registered tasks.
     * @param options
     */
    tree(options?: { deep?: boolean }): Node[] | string[];

    /**
     * Takes a string or function (task) and returns a timestamp of the last time the task was run successfully.
     * The time will be the time the task started.  Returns undefined if the task has not been run.
     * @param task
     * @param timeResolution
     */
    lastRun(task: string, timeResolution?: number): number;
}

namespace Undertaker {

    export interface Task {
        (cb?: Function): any;
    }

    export interface TaskMethod {

        /**
         * Returns the registered function.
         * @param taskName
         */
        (taskName: string): Task;

        /**
         * Register the task by the taskName.
         * @param taskName
         * @param fn
         */
        (taskName: string, fn: Task): void;

        /**
         * Register the task by the name property of the function.
         * @param fn
         */
        (fn: Task): void;

        /**
         * Register the task by the displayName property of the function.
         * @param fn
         */
        (fn: Task & { displayName: string }): void;
    }

    export interface Registry {

        /**
         * receives the undertaker instance to set pre-defined tasks using the task(taskName, fn) method.
         * @param taker
         */
        init(taker: Undertaker): void;

        /**
         * returns the task with that name or undefined if no task is registered with that name.
         * @param taskName
         */
        get(taskName: string): Task;

        /**
         * add task to the registry. If set modifies a task, it should return the new task.
         * @param taskName
         * @param fn
         */
        set(taskName: string, fn: Task): void;

        /**
         * returns an object listing all tasks in the registry.
         */
        tasks(): { [taskName: string]: Task };
    }

    export interface Node {
        label: string;
        type: string;
        nodes: Node[];
    }
}

export = Undertaker;
}

// Generated by typings
// Source: https://raw.githubusercontent.com/types/npm-gulp/e01fe07d5fb6dbe07a0e37492e90e4969badbda2/4.0.0-alpha.2/index.d.ts
declare module 'gulp' {
// Type definitions for Gulp v4.0.0-alpha.2
// Project: http://gulpjs.com
// Definitions by: Giedrius Grabauskas <https://github.com/GiedriusGrabauskas>

import * as vfs from '~gulp~vinyl-fs/index';
import * as chokidar from '~gulp~chokidar/index';
import Undertaker = require('~gulp~undertaker/index');
import * as fs from 'fs';
import { Duplex } from 'stream';

namespace GulpClient {

  export type Globs = string | Array<string>;

  type TasksArray<T> = Array<string | TaskFunction | T>;
  type Task = TasksArray<TasksArray<any>> | string | TaskFunction;

  interface Options extends vfs.SrcOptions {
    /**
     * When true, will allow singular globs to fail to match. Otherwise, globs which are only supposed to match one
     * file (such as ./foo/bar.js) will cause an error to be thrown if they don't match.
     * @default false
     */
    allowEmpty?: boolean;
  }

  export interface DestOptions {
    /**
     * cwd for the output folder, only has an effect if provided output folder is relative.
     * @default process.cwd()
     */
    cwd: string;

    /**
     * Octal permission specifying the mode the files should be created with: e.g. "0744", 0744 or 484 (0744 in base 10).
     * @default The mode of the input file (file.stat.mode) or the process mode if the input file has no mode property.
     */
    mode: string | number;

    /**
     * Octal permission specifying the mode the directory should be created with: e.g. "0755", 0755 or 493 (0755 in base 10).
     * Default is the process mode.
     */
    dirMode: string | number;

    /**
     * Specify if existing files with the same path should be overwritten or not.
     * @default true
     */
    overwrite: boolean;
  }

  interface SymlinkOptions {
    /**
     * cwd for the output folder, only has an effect if provided output folder is relative.
     * process.cwd()
     */
    cwd: string;

    /**
     * Octal permission specifying the mode the directory should be created with: e.g. "0755", 0755 or 493 (0755 in base 10).
     * @default Default is the process mode.
     */
    dirMode: string;
  }

  interface TaskFunctionParams {
    name?: string;
    displayName?: string;
    description?: string;
  }

  interface TaskFunction extends TaskFunctionParams {
    (done?: () => void): void | Duplex | NodeJS.Process | any;
  }

  export interface Gulp {
    /**
     * Emits files matching provided glob or array of globs. Returns a stream of Vinyl files that can be piped to plugins.
     * @param globs Glob or array of globs to read.
     * @param options Options to pass to node-glob through glob-stream.
     */
    src(globs: Globs, options?: Options): Duplex;

    /**
     * Can be piped to and it will write files. Re-emits all data passed to it so you can pipe to multiple folders.
     * Folders that don't exist will be created.
     * @param path The path (output folder) to write files to. Or a function that returns it, the function will be provided a vinyl File instance.
     * @param options
     */
    dest(path: string, options?: DestOptions): Duplex;

    /**
     * Functions exactly like gulp.dest, but will create symlinks instead of copying a directory.
     * @param folder A folder path or a function that receives in a file and returns a folder path.
     * @param options
     */
    symlink(folder: string | Function, options?: SymlinkOptions): Duplex;

    /**
     * Define a task exposed to gulp-cli, gulp.series, gulp.parallel and gulp.lastRun; inherited from undertaker.
     * @param name The name argument is required if the name and displayName properties of fn are empty.
     * @param dependencies The gulp tasks to run before starting this one.
     * @param fn The function that performs the task's operations.
     */
    task(fn: TaskFunction): TaskFunction;
    task(name: string): TaskFunction;
    task(name: string, tasks: string[]): TaskFunction;
    task(name: string, fn: TaskFunction): TaskFunction;
    task(name: string, dependencies: string[], fn: TaskFunction): TaskFunction;

    /**
     * Returns the timestamp of the last time the task ran successfully. The time will be the time the task started.
     * Returns undefined if the task has not run yet.
     * @param taskName The name of the registered task or of a function
     * @param timeResolution Set the time resolution of the returned timestamps.
     */
    lastRun(taskName: string, timeResolution?: number): number;

    /**
     * Takes a number of task names or functions and returns a function of the composed tasks or functions.
     * When using task names, the task should already be registered.
     * When the returned function is executed, the tasks or functions will be executed in parallel, all being executed at the same
     * time. If an error occurs, all execution will complete.
     */
    parallel(task: Task): TaskFunction;
    parallel(...tasks: Array<Task>): TaskFunction;
    parallel(tasks: Array<Task>): TaskFunction;

    /**
     * Takes a number of task names or functions and returns a function of the composed tasks or functions.
     * When using task names, the task should already be registered.
     * When the returned function is executed, the tasks or functions will be executed in series, each waiting for the prior to finish.
     * If an error occurs, execution will stop.
     */
    series(task: Task): TaskFunction;
    series(...tasks: Array<Task>): TaskFunction;
    series(tasks: Array<Task>): TaskFunction;

    /**
     * akes a path string, an array of path strings, a glob string or an array of glob strings as globs to watch on the filesystem.
     * Also optionally takes options to configure the watcher and a fn to execute when a file changes.
     * @globs A path string, an array of path strings, a glob string or an array of glob strings that indicate which files to watch for changes.
     * @opts Options that are passed to chokidar.
     * @fn Once async completion is signalled, if another run is queued, it will be executed.
     */
    watch(globs: Globs): fs.FSWatcher;
    watch(globs: Globs, fn: TaskFunction): fs.FSWatcher;
    watch(globs: Globs, opts: WatchOptions): fs.FSWatcher;
    watch(globs: Globs, opts: WatchOptions, fn: TaskFunction): fs.FSWatcher;

    /**
     * Returns the tree of tasks. Inherited from undertaker. See the undertaker docs for this function.
     * @param options Options to pass to undertaker.
     */
    tree(options?: TreeOptions): any;

    registry(registry?: Undertaker.Registry): Undertaker.Registry;
  }

  interface TreeOptions {
    /**
     * If set to true whole tree should be returned.
     * @default false
     */
    deep?: boolean;
  }

  interface WatchOptions extends chokidar.WatchOptions {
    /**
     * The delay to wait before triggering the fn.
     * Useful for waiting on many changes before doing the work on changed files, e.g. find-and-replace on many files.
     * @default 200
     */
    delay?: number;
    /**
     * Whether or not a file change should queue the fn execution if the fn is already running. Useful for a long running fn.
     * @default true
     */
    queue?: boolean;

    /**
     * If set to false the fn is called during chokidar instantiation as it discovers the file paths.
     * Useful if it is desirable to trigger the fn during startup. Passed through to chokidar, but defaulted to true instead of false.
     * @default true
     */
    ignoreInitial?: boolean;

    /**
     * Defines files/paths to be excluded from being watched.
     */
    ignored?: any;

    /**
     * The base directory from which watch paths are to be derived. Paths emitted with events will be relative to this.
     */
    cwd?: string;

    /**
     * If relying upon the fs.Stats object that may get passed as a second argument with add, addDir, and change events when available,
     * set this to true to ensure it is provided with every event. May have a slight performance penalty.
     * @default false
     */
    alwaysStat?: boolean;
  }

}

var GulpClient: GulpClient.Gulp;
export = GulpClient;
}
