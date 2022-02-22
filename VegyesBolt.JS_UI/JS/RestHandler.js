class RestHandler {
  url;
  port;
  constructor(url, port) {
    this.url = url;
    this.port = port;
  }
  _getApiUrl() {
    return `${this.url}:${this.port}/api`;
  }

  async fetchGetSomething(args) {
    const response = fetch(`${this._getApiUrl()}/${args}`);
    return await (await response).json();
  }

  async fetchDeleteSomething(args) {
    const response = fetch(`${this._getApiUrl()}/${args}`, {
      method: "DELETE",
    });
    return (await response).status;
  }

  /**
   *
   * @returns {Promise<Array.<MegyeHandler>>}
   */
  async fetchGetMegyek() {
    return (await this.fetchGetSomething("Megye")).map(
      (x) => new MegyeHandler(x)
    );
  }

  async fetchDeleteMegye(id) {
    return this.fetchDeleteSomething(`Megye/${id}`);
  }
}
