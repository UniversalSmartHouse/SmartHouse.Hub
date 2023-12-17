function sync(doc, oldDoc, meta) {
	if (doc._deleted) {
		requireUser(oldDoc.writers);

		return;
	}

	if (!doc.title || !doc.creator) {
		throw { forbidden: "Missing required properties" };
	} else if (doc.writers.length == 0) {
		throw { forbidden: "No writers" };
	}
	if (oldDoc == null) {
		requireUser(doc.creator);
	} else {
		requireUser(doc.creator);

		if (doc.creator != oldDoc.creator) {
			throw { forbidden: "Can't change creator" };
		}
	}
}
