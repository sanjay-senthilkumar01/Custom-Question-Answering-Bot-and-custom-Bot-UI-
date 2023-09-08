# Custom Bot UI for your Website and Web Chat Integration

**Overview:**

This README provides instructions and information on how to integrate a web chatbot into your website using the provided HTML and JavaScript code.

**Overview:**

This code enables you to integrate a web chatbot into your website. The chatbot is powered by the Microsoft Bot Framework Web Chat library and can be easily customized to fit the look and feel of your website.

**Prerequisites:**

Before you begin, make sure you have the following:

- A Microsoft Bot Framework bot with a Direct Line token.
- Basic knowledge of HTML, CSS, and JavaScript.
- Access to the HTML code of your website.

**Getting Started:**

Follow these steps to integrate the web chatbot into your website:

1. Copy the HTML code provided in this README and paste it into the HTML source code of your web page where you want the chatbot to appear.

2. Replace the `token: 'your Direct line Key here from azure'` in the JavaScript code with your actual Direct Line token from the Azure Bot Service. This token is required for the web chat to connect to your bot.

3. Customize the appearance of the chatbot by modifying the CSS styles within the `<style>` tags. You can adjust colors, sizes, and other styling attributes to match your website's design.

4. If you want to change the bot's name, modify the `QA-Bot` text within the `<span id="cover-name">QA-Bot</span>` element.

**Customization:**

You can further customize the chatbot's appearance and behavior by modifying the provided JavaScript code. Here are some customization options:

- **Changing the bot's name:** You can change the bot's name by updating the text within the `<span id="cover-name">` element.

- **Styling:** Customize the chat window's appearance by modifying the CSS styles defined within the `<style>` tags. You can change colors, sizes, and other visual aspects.

- **Timeout for resizing:** By default, the chat window will automatically reset to its initial size after 5 minutes of inactivity. You can adjust this timeout by changing the value passed to `resetToInitialSize` within the `startResizingTimeout` function.

- **Initial chat window size:** You can change the initial size of the chat window for different screen sizes by modifying the values within the `resetToInitialSize` function.

**Usage:**

Once you've integrated the code into your website and customized it to your liking, visitors to your website can interact with the chatbot by clicking on the chatbot icon. The chatbot will expand, allowing users to ask questions and receive responses.

**Troubleshooting:**

If you encounter any issues or have questions about integrating the chatbot into your website, refer to the Microsoft Bot Framework documentation or seek assistance from your development team.

**Credits:**

This integration is powered by the Microsoft Bot Framework Web Chat library. For more information about the library and its capabilities, visit [Bot Framework Web Chat documentation](https://github.com/microsoft/BotFramework-WebChat).
