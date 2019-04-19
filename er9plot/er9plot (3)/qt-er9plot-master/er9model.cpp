#include "er9Model.h"
#include <QtCore/QVector>
#include <QtCore/QTime>
#include <QtCore/QRect>
#include <QtGui/QColor>

ER9Model::ER9Model(QObject *parent, QString fileContent) :
    QAbstractTableModel(parent)
{
    m_columnCount = 11;
    parse(fileContent);
}

int ER9Model::rowCount(const QModelIndex &parent) const
{
    Q_UNUSED(parent)
    return m_data.count();
}

int ER9Model::columnCount(const QModelIndex &parent) const
{
    Q_UNUSED(parent)
    return m_columnCount;
}

QVariant ER9Model::headerData(int section, Qt::Orientation orientation, int role) const
{
    if (role != Qt::DisplayRole)
        return QVariant();

    if (orientation == Qt::Horizontal) {
        switch (section) {
        case 0: return "time";
        case 1: return "xAcc";
        case 2: return "yAcc";
        case 3: return "zAcc";
        case 4: return "xAng";
        case 5: return "yAng";
        case 6: return "zAng";
        case 7: return "xMag";
        case 8: return "yMag";
        case 9: return "zMag";
        case 10: return "temp";
        }
    } else {
        return QString("%1").arg(section + 1);
    }
    return "";
}

QVariant ER9Model::data(const QModelIndex &index, int role) const
{
    if (role == Qt::DisplayRole) {
        return m_data[index.row()]->at(index.column());
    } else if (role == Qt::EditRole) {
        return m_data[index.row()]->at(index.column());
    } else if (role == Qt::BackgroundRole) {
        foreach (QRect rect, m_mapping) {
            if (rect.contains(index.column(), index.row()))
                return QColor(m_mapping.key(rect));
        }
        // cell not mapped return white color
        return QColor(Qt::white);
    }
    return QVariant();
}

bool ER9Model::setData(const QModelIndex &index, const QVariant &value, int role)
{
    if (index.isValid() && role == Qt::EditRole) {
        m_data[index.row()]->replace(index.column(), value.toDouble());
        emit dataChanged(index, index);
        return true;
    }
    return false;
}

Qt::ItemFlags ER9Model::flags(const QModelIndex &index) const
{
    return QAbstractItemModel::flags(index) | Qt::ItemIsEditable;
}

void ER9Model::addMapping(QString color, QRect area)
{
    m_mapping.insertMulti(color, area);
}

void ER9Model::parse(QString fileContent)
{
    m_data.clear();
    QStringList lines = fileContent.split(QRegExp("[\r\n]"),QString::SkipEmptyParts);
    for(int i = 0; i < lines.length(); i++) {
        QString line = lines.at(i);
        QStringList values = line.split(",");
        // acceleration
        double xAcceleration = convertTwosComp(values.at(0).toInt()) / 2046.0;
        double yAcceleration = convertTwosComp(values.at(1).toInt()) / 2046.0;
        double zAcceleration = convertTwosComp(values.at(2).toInt()) / 2046.0;

        // temperature
        double celsius = convertTwosComp(values.at(3).toInt()) / 340.0 + 35.0;

        // angular velocity
        double xOmega = convertTwosComp(values.at(4).toInt()) / 16.4;
        double yOmega = convertTwosComp(values.at(5).toInt()) / 16.4;
        double zOmega = convertTwosComp(values.at(6).toInt()) / 16.4;

        // magnetometer
        double xHeading = convertTwosComp(values.at(7).toInt()) * 0.3e-6 / 8;
        double yHeading = convertTwosComp(values.at(8).toInt())* 0.3e-6 / 8;
        double zHeading = convertTwosComp(values.at(9).toInt())* 0.3e-6 / 8;

        QVector<qreal>* dataVec = new QVector<qreal>(m_columnCount);
        (*dataVec)[0] = (qreal)i * 0.01; // time
        (*dataVec)[1] = xAcceleration;
        (*dataVec)[2] = yAcceleration;
        (*dataVec)[3] = zAcceleration;
        (*dataVec)[4] = xOmega;
        (*dataVec)[5] = yOmega;
        (*dataVec)[6] = zOmega;
        (*dataVec)[7] = xHeading;
        (*dataVec)[8] = yHeading;
        (*dataVec)[9] = zHeading;
        (*dataVec)[10] = celsius;

        m_data.append(dataVec);
    }
}

int ER9Model::convertTwosComp(int value)
{
    return ((int)(0x7FFF) & value) - ((0x8000 & value) ? 32768 : 0);
}

QString ER9Model::toCSV() {
    QStringList csv("time, xAcc, yAcc, zAcc, xGyro, yGyro, zGyro, xMag, yMag, zMag, temperature");
    for(int i = 0; i < m_data.count(); i++ ) {
        csv << QString("%1, %2, %3, %4, %5, %6, %7, %8, %9, %10, %11")
                .arg(m_data.at(i)->at(0))
                .arg(m_data.at(i)->at(1))
                .arg(m_data.at(i)->at(2))
                .arg(m_data.at(i)->at(3))
                .arg(m_data.at(i)->at(4))
                .arg(m_data.at(i)->at(5))
                .arg(m_data.at(i)->at(6))
                .arg(m_data.at(i)->at(7))
                .arg(m_data.at(i)->at(8))
                .arg(m_data.at(i)->at(9))
                .arg(m_data.at(i)->at(10));
    }
    return csv.join("\n");
}
