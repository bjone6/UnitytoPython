from flask import Flask, request, jsonify

app = Flask(__name__)

latest_message = ""


@app.post("/send")
def receive_from_unity():
    global latest_message
    data = request.get_json()
    latest_message = data.get("message", "")
    print("Unity said:", latest_message)
    return jsonify({"reply": f"Python received: {latest_message}"})


@app.get("/latest")
def latest():
    return jsonify({"message": latest_message})


if __name__ == "__main__":
    app.run(host="127.0.0.1", port=5000)
