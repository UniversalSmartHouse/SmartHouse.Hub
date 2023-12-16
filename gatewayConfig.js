function (doc, oldDoc) {
    if (doc._deleted) {
        // Логіка для видалених документів
        return;
    }
    channel(doc.channels);
}