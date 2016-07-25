/*
 * Edited: Mike Broman
 *
*/

(function () {
    'use strict';

    angular
        .module('custom', [
            // request the the entire framework
            'cattletracker',

            // or modules
            'app.core',
            'app.sidebar'
        ]);
})();