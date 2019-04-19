#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "er9model.h"


namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private:
    Ui::MainWindow *ui;
    ER9Model* model;

public slots:
    void onOpen();
    void onExport();
};

#endif // MAINWINDOW_H
