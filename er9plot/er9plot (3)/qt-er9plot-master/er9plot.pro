#-------------------------------------------------
#
# Project created by QtCreator 2017-08-09T19:31:39
#
#-------------------------------------------------

QT       += core gui charts

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = er9plot
TEMPLATE = app

# The following define makes your compiler emit warnings if you use
# any feature of Qt which as been marked as deprecated (the exact warnings
# depend on your compiler). Please consult the documentation of the
# deprecated API in order to know how to port your code away from it.
DEFINES += QT_DEPRECATED_WARNINGS

# You can also make your code fail to compile if you use deprecated APIs.
# In order to do so, uncomment the following line.
# You can also select to disable deprecated APIs only up to a certain version of Qt.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0


SOURCES += \
        main.cpp \
        mainwindow.cpp \
    er9model.cpp

HEADERS += \
        mainwindow.h \
    er9model.h

FORMS += \
        mainwindow.ui

# defines application icon for win32 build
RC_FILE = er9plot.rc

# defines applicaiton icon for OSX
ICON = ER.icns

DISTFILES += \
    er9plot.rc
