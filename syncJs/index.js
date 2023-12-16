const fs = require("fs");

const filepath = "../gatewayConfig.js";

fs.watch(filepath, (eventType, filename) => {
	if (filename) {
		console.log(`${filename} file Changed`);

		fs.readFile(filepath, "utf8", (err, data) => {
			if (err) {
				console.error(err);
				return;
			}

			fs.readFile(filepath + "on", "utf8", (err, jsonData) => {
				if (err) {
					console.error(err);
					return;
				}

				const json = JSON.parse(jsonData);

				json.databases.db.sync = data.toString();

				fs.writeFile(filepath + "on", JSON.stringify(json, null, 2), (err) => {
					if (err) {
						console.error(err);
						return;
					}
					console.log("Data successfully updated and written to file");
				});
			});
		});
	} else {
		console.log("filename not provided");
	}
});
//function (doc, oldDoc) { if (doc.sdk) { channel(doc.sdk); } }
