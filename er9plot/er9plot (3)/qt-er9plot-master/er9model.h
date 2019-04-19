#ifndef ER9MODEL_H
#define ER9MODEL_H

#include <QAbstractTableModel>
#include <QRect>

class ER9Model : public QAbstractTableModel
{
    Q_OBJECT
public:
    explicit ER9Model(QObject *parent = 0, QString fileContent = "");

    int rowCount(const QModelIndex &parent = QModelIndex()) const;
    int columnCount(const QModelIndex &parent = QModelIndex()) const;
    QVariant headerData(int section, Qt::Orientation orientation, int role = Qt::DisplayRole) const;
    QVariant data(const QModelIndex &index, int role = Qt::DisplayRole) const;
    bool setData(const QModelIndex &index, const QVariant &value, int role = Qt::EditRole);
    Qt::ItemFlags flags(const QModelIndex &index) const;

    void addMapping(QString color, QRect area);
    void clearMapping() { m_mapping.clear(); }
    QString toCSV();

private:
    void parse(QString);
    int convertTwosComp(int);

    QList<QVector<qreal> * > m_data;
    QHash<QString, QRect> m_mapping;
    int m_columnCount;
};

#endif // ER9MODEL_H
