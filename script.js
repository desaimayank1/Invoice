document.addEventListener('DOMContentLoaded', function() {
    fetch('/api/invoice')
        .then(resp => {
            if (!resp.ok) throw new Error('Network response was not ok');
            return resp.json();
        })
        .then(dataArray => {
            if (!dataArray.length) {
                document.getElementById('invoice-container').innerHTML = "<p>No invoices found</p>";
                return;
            }

            let html = '';
            dataArray.forEach(data => {
                html += `<h2>Invoice #${data.invoiceId ?? data.InvoiceId}</h2>`;
                html += `<p>Customer: ${data.customerName ?? data.CustomerName}</p>`;
                html += '<ul>';
                const items = data.items ?? data.Items ?? [];
                items.forEach(item => {
                    html += `<li>${item.name ?? item.Name} - $${(item.price ?? item.Price).toFixed(2)}</li>`;
                });
                html += '</ul>';
                const total = items.reduce((sum, item) => sum + (item.price ?? item.Price), 0);
                html += `<p><strong>Total: $${total.toFixed(2)}</strong></p>`;
                html += '<hr>'; // optional separator between invoices
            });

            document.getElementById('invoice-container').innerHTML = html;
        })
        .catch(err => console.error("Failed to load invoices:", err));
});
