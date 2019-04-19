#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QtWidgets/QTableView>
#include <QtCharts/QChart>
#include <QtCharts/QChartView>
#include <QtCharts/QLineSeries>
#include <QtCharts/QVXYModelMapper>

#include <QFile>
#include <QFileDialog>
#include <QMessageBox>
#include <QPushButton>
#include <QSpacerItem>

QT_CHARTS_USE_NAMESPACE

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    connect(ui->action_Open, SIGNAL(triggered(bool)), SLOT(onOpen()));
    connect(ui->action_Export, SIGNAL(triggered(bool)), SLOT(onExport()));

    QPushButton* loadButton = new QPushButton;
    loadButton->setText("Load CSV");
    connect(loadButton, SIGNAL(clicked(bool)), SLOT(onOpen()));

    QVBoxLayout* vLayout = new QVBoxLayout;
    vLayout->addItem(new QSpacerItem(0,10, QSizePolicy::Expanding, QSizePolicy::Expanding));
    vLayout->addWidget(loadButton);
    vLayout->addItem(new QSpacerItem(0,10, QSizePolicy::Expanding, QSizePolicy::Expanding));
    QHBoxLayout* hLayout = new QHBoxLayout;
    hLayout->addItem(new QSpacerItem(0,10, QSizePolicy::Expanding, QSizePolicy::Expanding));
    hLayout->addLayout(vLayout);
    hLayout->addItem(new QSpacerItem(0,10, QSizePolicy::Expanding, QSizePolicy::Expanding));
    ui->tableTab->setLayout(hLayout);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::onOpen() {
    QFile file(QFileDialog::getOpenFileName(this, tr("Open"), "", tr("ER9DOF Files (*.csv)")));
    if (file.open(QIODevice::ReadOnly)) {
        QString fileContent = QString::fromLatin1(file.readAll());
        model = new ER9Model(this, fileContent);
        file.close();
        // box.setText(QString("parsed %1 lines").arg(model->rowCount()));
    } else {
        QMessageBox box;
        box.setText("Failed to open file");
        box.exec();
        return;
    }

    QTableView *tableView = new QTableView;
    tableView->setModel(model);
    tableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
    tableView->verticalHeader()->setSectionResizeMode(QHeaderView::Stretch);

    QGridLayout *layout = new QGridLayout;
    layout->addWidget(tableView, 0, 0, 1, 1);
    if (ui->tableTab->layout())
        delete ui->tableTab->layout(); // prepare tab for new content
    ui->tableTab->setLayout(layout); // set new content


    // acceleration chart
    QChart *chart = new QChart();
    chart->setTitle("Acceleration");

    // series 1
    QLineSeries *series = new QLineSeries;
    series->setName("xAcc");
    QVXYModelMapper *mapper = new QVXYModelMapper(this);
    mapper->setModel(model);
    mapper->setXColumn(0);
    mapper->setYColumn(1);
    mapper->setSeries(series);
    chart->addSeries(series);

    // series 2
    series = new QLineSeries;
    series->setName("yAcc");
    mapper = new QVXYModelMapper(this);
    mapper->setModel(model);
    mapper->setXColumn(0);
    mapper->setYColumn(2);
    mapper->setSeries(series);
    chart->addSeries(series);

    // series 2
    series = new QLineSeries;
    series->setName("zAcc");
    mapper = new QVXYModelMapper(this);
    mapper->setModel(model);
    mapper->setXColumn(0);
    mapper->setYColumn(3);
    mapper->setSeries(series);
    chart->addSeries(series);

    chart->createDefaultAxes();

    QChartView *chartView = new QChartView(chart);
    chartView->setRenderHint(QPainter::Antialiasing);
    chartView->setMinimumSize(640, 480);
    chartView->setRubberBand(QChartView::HorizontalRubberBand);

    layout = new QGridLayout;
    layout->addWidget(chartView, 0, 0, 1, 1);

    if (ui->acceltab->layout())
        delete ui->acceltab->layout(); // prepare tab for new content
    ui->acceltab->setLayout(layout); // set new content

    // Gyroscope chart
    chart = new QChart();
    chart->setTitle("Gyroscope");

    series = new QLineSeries;
    series->setName("xGyro");
    mapper = new QVXYModelMapper(this);
    mapper->setModel(model);
    mapper->setXColumn(0);
    mapper->setYColumn(4);
    mapper->setSeries(series);
    chart->addSeries(series);

    series = new QLineSeries;
    series->setName("yGyro");
    mapper = new QVXYModelMapper(this);
    mapper->setModel(model);
    mapper->setXColumn(0);
    mapper->setYColumn(5);
    mapper->setSeries(series);
    chart->addSeries(series);

    series = new QLineSeries;
    series->setName("zGyro");
    mapper = new QVXYModelMapper(this);
    mapper->setModel(model);
    mapper->setXColumn(0);
    mapper->setYColumn(6);
    mapper->setSeries(series);
    chart->addSeries(series);

    chart->createDefaultAxes();

    chartView = new QChartView(chart);
    chartView->setRenderHint(QPainter::Antialiasing);
    chartView->setMinimumSize(640, 480);
    chartView->setRubberBand(QChartView::HorizontalRubberBand);

    layout = new QGridLayout;
    layout->addWidget(chartView, 0, 0, 1, 1);

    if (ui->gyroTab->layout())
        delete ui->gyroTab->layout(); // prepare tab for new content
    ui->gyroTab->setLayout(layout); // set new content

    // magnetometer chart
    chart = new QChart();
    chart->setTitle("Magnetometer");

    series = new QLineSeries;
    series->setName("xMag");
    mapper = new QVXYModelMapper(this);
    mapper->setModel(model);
    mapper->setXColumn(0);
    mapper->setYColumn(7);
    mapper->setSeries(series);
    chart->addSeries(series);

    series = new QLineSeries;
    series->setName("yMag");
    mapper = new QVXYModelMapper(this);
    mapper->setModel(model);
    mapper->setXColumn(0);
    mapper->setYColumn(8);
    mapper->setSeries(series);
    chart->addSeries(series);

    series = new QLineSeries;
    series->setName("zMag");
    mapper = new QVXYModelMapper(this);
    mapper->setModel(model);
    mapper->setXColumn(0);
    mapper->setYColumn(9);
    mapper->setSeries(series);
    chart->addSeries(series);

    chart->createDefaultAxes();

    chartView = new QChartView(chart);
    chartView->setRenderHint(QPainter::Antialiasing);
    chartView->setMinimumSize(640, 480);
    chartView->setRubberBand(QChartView::HorizontalRubberBand);

    layout = new QGridLayout;
    layout->addWidget(chartView, 0, 0, 1, 1);

    if (ui->magTab->layout())
        delete ui->magTab->layout(); // prepare tab for new content
    ui->magTab->setLayout(layout); // set new content

    // temperature chart
    chart = new QChart();
    chart->setTitle("Temperature");

    series = new QLineSeries;
    series->setName("temperature");
    mapper = new QVXYModelMapper(this);
    mapper->setModel(model);
    mapper->setXColumn(0);
    mapper->setYColumn(10);
    mapper->setSeries(series);
    chart->addSeries(series);
    chart->createDefaultAxes();

    chartView = new QChartView(chart);
    chartView->setRenderHint(QPainter::Antialiasing);
    chartView->setMinimumSize(640, 480);
    chartView->setRubberBand(QChartView::HorizontalRubberBand);

    layout = new QGridLayout;
    layout->addWidget(chartView, 0, 0, 1, 1);

    if (ui->tempuratureTab->layout())
        delete ui->tempuratureTab->layout(); // prepare tab for new content
    ui->tempuratureTab->setLayout(layout); // set new content
}

void MainWindow::onExport() {
    QFile file(QFileDialog::getSaveFileName(this, tr("Export CSV"), "", tr("ER9DOF Files (*.csv)")));
    if (!file.open(QIODevice::ReadWrite)) {
        QMessageBox box;
        box.setText("Failed to open file.");
        box.exec();
        return;
    }
    QString content = model->toCSV();
    file.write(content.toLatin1());
    file.close();
}
