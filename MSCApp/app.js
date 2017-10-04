/// <reference path="assets/js/angular.min.js" />

'use strict';

// Declare app level module which depends on views, and components
var wiziqApp = angular.module('wiziqApp', ["ngRoute", "ngMessages", "ui.router", "angularjs-datetime-picker"]);

wiziqApp.config(['$routeProvider', '$locationProvider', '$stateProvider', function ($routeProvider, $locationProvider, $stateProvider) {
    $stateProvider

        ////// -------------- States for Admin-----------------------------
        .state('login', {
            url: '/login',
            templateUrl: '/index.html'
        })
        .state('admin', {
            url: '/admin',
            templateUrl: '/app/admin/index.html',
            controller: 'AdminController'
        })
        .state('admin/home', {
            url: '/admin/home',
            templateUrl: '/app/admin/index.html'
        })


        ////// -------------- States for Admin Teacher-----------------------------
        .state('admin/manage-teacher', {
            url: '/admin/manage-teacher',
            templateUrl: '/app/admin/feature/teacher/partials/manage-teacher.html'
        })
        .state('admin/create-teacher', {
            url: '/admin/create-teacher',
            templateUrl: '/app/admin/feature/teacher/partials/create-teacher.html'
        })
        .state('admin/update-teacher', {
            url: '/admin/update-teacher/:teacherId',
            templateUrl: '/app/admin/feature/teacher/partials/update-teacher.html'
        })

        ////// -------------- States for Admin Class-----------------------------
        .state('admin/manage-class', {
            url: '/admin/manage-class',
            templateUrl: '/app/admin/feature/class/partials/manage-class.html'
        })
        .state('admin/create-class', {
            url: '/admin/create-class',
            templateUrl: '/app/admin/feature/class/partials/create-class.html'
        })
        .state('admin/update-class', {
            url: '/admin/update-class/:classId',
            templateUrl: '/app/admin/feature/class/partials/update-class.html'
        })


        ////// -------------- States for Admin Batch-----------------------------
        .state('admin/manage-batch', {
            url: '/admin/manage-batch',
            templateUrl: '/app/admin/feature/batch/partials/manage-batch.html'
        })
        .state('admin/create-batch', {
            url: '/admin/create-batch',
            templateUrl: '/app/admin/feature/batch/partials/create-batch.html'
        })
        .state('admin/update-batch', {
            url: '/admin/update-batch/:batchId',
            templateUrl: '/app/admin/feature/batch/partials/update-batch.html'
        })


        ////// -------------- States for Admin Grade-----------------------------
        .state('admin/manage-grade', {
            url: '/admin/manage-grade',
            templateUrl: '/app/admin/feature/grade/partials/manage-grade.html'
        })
        .state('admin/create-grade', {
            url: '/admin/create-grade',
            templateUrl: '/app/admin/feature/grade/partials/create-grade.html'
        })
        .state('admin/update-grade', {
            url: '/admin/update-grade/:gradeId',
            templateUrl: '/app/admin/feature/grade/partials/update-grade.html'
        })


        ////// -------------- States for Admin Student-----------------------------
        .state('admin/manage-student', {
            url: '/admin/manage-student',
            templateUrl: '/app/admin/feature/student/partials/manage-student.html'
        })
        .state('admin/create-student', {
            url: '/admin/create-student',
            templateUrl: '/app/admin/feature/student/partials/create-student.html'
        })
        .state('admin/update-student', {
            url: '/admin/update-student/:studentId',
            templateUrl: '/app/admin/feature/student/partials/update-student.html'
        })


        ////// -------------- States for Admin Subject-----------------------------
        .state('admin/manage-subject', {
            url: '/admin/manage-subject',
            templateUrl: '/app/admin/feature/subject/partials/manage-subject.html'
        })
        .state('admin/create-subject', {
            url: '/admin/create-subject',
            templateUrl: '/app/admin/feature/subject/partials/create-subject.html'
        })
        .state('admin/update-subject', {
            url: '/admin/update-subject/:subjectId',
            templateUrl: '/app/admin/feature/subject/partials/update-subject.html'
        })

        ////// -------------- States for Admin Course-----------------------------
        .state('admin/manage-course', {
            url: '/admin/manage-course',
            templateUrl: '/app/admin/feature/course/partials/manage-course.html'
        })
        .state('admin/create-course', {
            url: '/admin/create-course',
            templateUrl: '/app/admin/feature/course/partials/create-course.html'
        })
        .state('admin/update-course', {
            url: '/admin/update-course/:courseId',
            templateUrl: '/app/admin/feature/course/partials/update-course.html'
        })


        ////// -------------- States for Student -----------------------------
        .state('student', {
            url: '/student',
            templateUrl: '/app/student/partials/student-home.html'
        })
        .state('student/home', {
            url: '/student/home',
            templateUrl: '/app/student/partials/student-home.html'
        })
        .state('student/my-profile', {
            url: '/student/my-profile',
            templateUrl: '/app/student/partials/my-profile.html'
        })
        .state('student/live-classes', {
            url: '/student/live-classes',
            templateUrl: '/app/student/partials/live-classes.html'
        })
        .state('student/recorded-classes', {
            url: '/student/recorded-classes',
            templateUrl: '/app/student/partials/recorded-classes.html'
        })
        .state('student/download-recordings', {
            url: '/student/download-recordings',
            templateUrl: '/app/student/partials/download-recordings.html'
        })

        ////// -------------- States for Tutor -----------------------------
        .state('tutor', {
            url: '/tutor',
            templateUrl: '/app/tutor/partials/tutor-home.html'
        })
        .state('tutor/home', {
            url: 'tutor/home',
            templateUrl: '/app/tutor/partials/tutor-home.html'
        })
        .state('tutor/my-profile', {
            url: '/tutor/my-profile',
            templateUrl: '/app/tutor/partials/my-profile.html'
        })
        .state('tutor/live-classes', {
            url: '/tutor/live-classes',
            templateUrl: '/app/tutor/partials/live-classes.html'
        })
        .state('tutor/recorded-classes', {
            url: '/tutor/recorded-classes',
            templateUrl: '/app/tutor/partials/recorded-classes.html'
        })
        .state('tutor/download-recordings', {
            url: '/tutor/download-recordings',
            templateUrl: '/app/tutor/partials/download-recordings.html'
        });

    //.otherwise({ template: "<h2>Broaken link.</h2>" });

    $locationProvider.html5Mode(true);
}]);





