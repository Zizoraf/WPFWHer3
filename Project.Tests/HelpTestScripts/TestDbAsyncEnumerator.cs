using System.Text.Json;

internal class AsyncEnumerator<T> : IAsyncEnumerator<T>, IAsyncDisposable, IDisposable
{
    private readonly IEnumerator<T> enumerator;

    private Utf8JsonWriter? _jsonWriter = new(new MemoryStream());

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);

        Dispose(disposing: false);
#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize

        GC.SuppressFinalize(this);
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _jsonWriter?.Dispose();
            _jsonWriter = null;
        }
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (_jsonWriter is not null)
        {
            await _jsonWriter.DisposeAsync().ConfigureAwait(false);
        }

        _jsonWriter = null;
    }

    public AsyncEnumerator(IEnumerator<T> enumerator) =>
        this.enumerator = enumerator ?? throw new ArgumentNullException();

    public T Current => enumerator.Current;

    public ValueTask<bool> MoveNextAsync() =>
        new ValueTask<bool>(enumerator.MoveNext());
}