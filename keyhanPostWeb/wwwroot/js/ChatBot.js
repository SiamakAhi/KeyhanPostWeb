let chatIsOpen = false;
let questionsLoaded = false;

function openChat() {
    const widget = document.getElementById("chatWidget");
    const badge = document.getElementById("newMessageBadge");

    widget.classList.remove("hidden");
    badge.classList.add("hidden");
    chatIsOpen = true;

    if (!questionsLoaded) {
        setTimeout(loadQuestions, 500);
        questionsLoaded = true;
    }
}

function closeChat() {
    document.getElementById("chatWidget").classList.add("hidden");
    chatIsOpen = false;
}

function loadQuestions() {
    const chatBody = document.getElementById("chatBody");

    // نمایش انیمیشن تایپ
    showTypingIndicator();

    setTimeout(() => {
        hideTypingIndicator();

        const container = document.createElement("div");
        container.id = "questionList";
        container.className = "space-y-2 message-appear";

        const questions = [
            {
                q: "چطور میتونم بسته‌ام رو رهگیری کنم؟",
                a: "برای رهگیری بسته خود، کد رهگیری را در بخش 'پیگیری مرسوله' وارد کنید."
            },
            {
                q: "هزینه ارسال چقدره؟",
                a: "هزینه ارسال بسته به وزن، ابعاد و شهر مقصد محاسبه می‌شود. برای محاسبه دقیق، از ماشین حساب هزینه در سایت استفاده کنید."
            },
            {
                q: "چقدر طول می‌کشه بسته برسه؟",
                a: "زمان تحویل بسته به نوع ارسال متفاوته:\n• ارسال بین‌المللی: بین 7 الی 11 روز کاری\n• سرویس اکسپرس: 24 ساعت\n• سرویس عادی: 24 الی 48 ساعت"
            },
            {
                q: "آیا امکان تغییر آدرس وجود داره؟",
                a: "بله، تا زمانی که بسته از مبدا ارسال نشده، امکان تغییر آدرس وجود دارد. با شماره 32921023-061 تماس بگیرید."
            }
        ];

        questions.forEach((item, index) => {
            const btn = document.createElement("button");
            btn.className = "w-full bg-white border border-gray-200 p-3 rounded-xl text-right hover:bg-green-50 hover:border-green-200 transition-all text-sm leading-relaxed shadow-sm";
            btn.innerHTML = `<i class="fas fa-question-circle text-green-600 ml-2"></i>${item.q}`;
            btn.onclick = () => sendAnswer(item.q, item.a);

            setTimeout(() => {
                container.appendChild(btn);
            }, index * 100);
        });

        chatBody.appendChild(container);
        scrollToBottom();
    }, 1500);
}

function showTypingIndicator() {
    const chatBody = document.getElementById("chatBody");

    const typingDiv = document.createElement("div");
    typingDiv.id = "typingIndicator";
    typingDiv.className = "flex justify-start items-start space-x-2 space-x-reverse message-appear";

    typingDiv.innerHTML = `
                <div class="w-8 h-8 rounded-full bg-green-600 text-white flex items-center justify-center flex-shrink-0">
                    <i class="fas fa-robot text-xs"></i>
                </div>
                <div class="bg-white p-3 rounded-2xl rounded-tr-md shadow-sm">
                    <div class="flex space-x-1">
                        <div class="typing-indicator"></div>
                        <div class="typing-indicator"></div>
                        <div class="typing-indicator"></div>
                    </div>
                </div>
            `;

    chatBody.appendChild(typingDiv);
    scrollToBottom();
}

function hideTypingIndicator() {
    const indicator = document.getElementById("typingIndicator");
    if (indicator) {
        indicator.remove();
    }
}

function sendAnswer(question, answer) {
    const chatBody = document.getElementById("chatBody");

    // حذف لیست سوالات
    const qList = document.getElementById("questionList");
    if (qList) qList.remove();

    // پیام کاربر
    const userRow = document.createElement("div");
    userRow.className = "flex justify-end items-start space-x-2 space-x-reverse message-appear";

    userRow.innerHTML = `
                <div class="bg-gradient-to-r from-green-600 to-green-700 text-white p-3 rounded-2xl rounded-tl-md max-w-[75%] shadow-sm">
                    <p class="text-sm leading-relaxed">${question}</p>
                </div>
                <div class="w-8 h-8 rounded-full bg-gray-300 flex items-center justify-center flex-shrink-0">
                    <i class="fas fa-user text-gray-600 text-xs"></i>
                </div>
            `;

    chatBody.appendChild(userRow);
    scrollToBottom();

    // نمایش انیمیشن تایپ
    setTimeout(() => {
        showTypingIndicator();

        setTimeout(() => {
            hideTypingIndicator();

            // پاسخ سیستم
            const botRow = document.createElement("div");
            botRow.className = "flex justify-start items-start space-x-2 space-x-reverse message-appear";

            const formattedAnswer = answer.replace(/\n/g, '<br>');

            botRow.innerHTML = `
                        <div class="w-8 h-8 rounded-full bg-green-600 text-white flex items-center justify-center flex-shrink-0">
                            <i class="fas fa-robot text-xs"></i>
                        </div>
                        <div class="bg-white p-3 rounded-2xl rounded-tr-md max-w-[75%] shadow-sm">
                            <p class="text-gray-800 text-sm leading-relaxed">${formattedAnswer}</p>
                        </div>
                    `;

            chatBody.appendChild(botRow);
            scrollToBottom();

            // نمایش دوباره سوالات
            setTimeout(() => {
                showMoreQuestionsButton();
            }, 1000);

        }, 1500);
    }, 500);
}

function showMoreQuestionsButton() {
    const chatBody = document.getElementById("chatBody");

    const moreBtn = document.createElement("div");
    moreBtn.className = "flex justify-center message-appear";
    moreBtn.innerHTML = `
                <button onclick="loadQuestions()" class="bg-gray-100 hover:bg-gray-200 text-gray-700 px-4 py-2 rounded-full text-sm transition-colors">
                    <i class="fas fa-redo ml-1"></i>
                    سوالات بیشتر
                </button>
            `;

    chatBody.appendChild(moreBtn);
    scrollToBottom();
}

function showContactOptions() {
    document.getElementById("contactModal").classList.remove("hidden");
}

function closeContactModal() {
    document.getElementById("contactModal").classList.add("hidden");
}

function scrollToBottom() {
    const chatBody = document.getElementById("chatBody");
    setTimeout(() => {
        chatBody.scrollTop = chatBody.scrollHeight;
    }, 100);
}



// بستن مودال با کلیک خارج از آن
document.getElementById("contactModal").addEventListener("click", function (e) {
    if (e.target === this) {
        closeContactModal();
    }
});
   