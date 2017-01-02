#include "notedviewer.h"
#include "ui_notedviewer.h"

NotedViewer::NotedViewer(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::NotedViewer)
{
    ui->setupUi(this);
}

NotedViewer::~NotedViewer()
{
    db.close();
    delete ui;
}

void NotedViewer::on_browseButton_clicked()
{
    //
    // Select the Noted SQLite file
    QString filePath = QFileDialog::getOpenFileName(this, tr("Open NBAK File"), QString(), tr("nbak Files (*.nbak);;Any (*.*)"));
    if(filePath.isEmpty())
    {
        return;
    }

    // Fill out the path box
    ui->nbakPath->setText(filePath);

    // Load the SQLite file
    // http://stackoverflow.com/questions/27844759/how-to-create-a-sqlite-database-in-qt
    // [LINK AGAINST SQL!!] http://www.qtcentre.org/archive/index.php/t-7016.html
    db = QSqlDatabase::addDatabase("QSQLITE");
    db.setDatabaseName(filePath);
    db.open();

    // Populate the categories list
    // http://stackoverflow.com/questions/6003086/qlistwidget-or-qlistview-with-qitemdelegate
    QSqlQuery query;
    query.exec("select distinct noteType from note");
    while(query.next()){
        QString category = query.value(0).toString();

        // Create the list item and add it to the list
        // http://www.qtcentre.org/threads/52254-Add-Items-to-QListView
        ui->categoriesList->addItem(category);
    }
}

void NotedViewer::on_categoriesList_itemClicked(QListWidgetItem *item)
{
    // Set the selected category
    categorySelected = item->text();

    // Clear existing notes selection (if any)
    ui->notesList->clear();

    // Load list of notes in the category
    QSqlQuery query;
    query.exec("select * from note where noteType = '" + item->text() + "'" );
    while(query.next()){
        QString noteTitle = query.value("noteTitle").toString();
        ui->notesList->addItem(noteTitle);
    }
}

void NotedViewer::on_notesList_itemClicked(QListWidgetItem *item)
{
    // Set note name
    ui->noteTitle->setText(item->text());

    // Clear note contents
    ui->noteText->setText("");

    // Load note text
    QSqlQuery query;
    query.exec("select * from note where noteType = '" + categorySelected + "' and noteTitle = '" + item->text() + "'");
    query.next();

    // Set note contents
    ui->noteText->setText(query.value("noteText").toString());
}
