// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Communication;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.CallingServer
{
    internal partial class CallRestClient
    {
        private string endpoint;
        private string apiVersion;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of CallRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The endpoint of the Azure Communication resource. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        public CallRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string apiVersion = "2021-04-15-preview1")
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }

            this.endpoint = endpoint;
            this.apiVersion = apiVersion;
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreateCreateCallRequest(IEnumerable<CommunicationIdentifierModel> targets, CommunicationIdentifierModel source, string callbackUri, IEnumerable<CallModality> requestedModalities, IEnumerable<EventSubscriptionType> requestedCallEvents, PhoneNumberIdentifierModel sourceAlternateIdentity, string subject)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/calling/calls", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var model = new CreateCallRequestInternal(targets.ToList(), source, callbackUri, requestedModalities.ToList(), requestedCallEvents.ToList())
            {
                SourceAlternateIdentity = sourceAlternateIdentity,
                Subject = subject
            };
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(model);
            request.Content = content;
            return message;
        }

        /// <summary> Create a new call. </summary>
        /// <param name="targets"> The targets of the call. </param>
        /// <param name="source"> The source of the call. </param>
        /// <param name="callbackUri"> The callback URI. </param>
        /// <param name="requestedModalities"> The requested modalities. </param>
        /// <param name="requestedCallEvents"> The requested call events to subscribe to. </param>
        /// <param name="sourceAlternateIdentity"> The alternate identity of the source of the call if dialing out to a pstn number. </param>
        /// <param name="subject"> The subject. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targets"/>, <paramref name="source"/>, <paramref name="callbackUri"/>, <paramref name="requestedModalities"/>, or <paramref name="requestedCallEvents"/> is null. </exception>
        public async Task<Response<CreateCallResponse>> CreateCallAsync(IEnumerable<CommunicationIdentifierModel> targets, CommunicationIdentifierModel source, string callbackUri, IEnumerable<CallModality> requestedModalities, IEnumerable<EventSubscriptionType> requestedCallEvents, PhoneNumberIdentifierModel sourceAlternateIdentity = null, string subject = null, CancellationToken cancellationToken = default)
        {
            if (targets == null)
            {
                throw new ArgumentNullException(nameof(targets));
            }
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (callbackUri == null)
            {
                throw new ArgumentNullException(nameof(callbackUri));
            }
            if (requestedModalities == null)
            {
                throw new ArgumentNullException(nameof(requestedModalities));
            }
            if (requestedCallEvents == null)
            {
                throw new ArgumentNullException(nameof(requestedCallEvents));
            }

            using var message = CreateCreateCallRequest(targets, source, callbackUri, requestedModalities, requestedCallEvents, sourceAlternateIdentity, subject);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    {
                        CreateCallResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = CreateCallResponse.DeserializeCreateCallResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Create a new call. </summary>
        /// <param name="targets"> The targets of the call. </param>
        /// <param name="source"> The source of the call. </param>
        /// <param name="callbackUri"> The callback URI. </param>
        /// <param name="requestedModalities"> The requested modalities. </param>
        /// <param name="requestedCallEvents"> The requested call events to subscribe to. </param>
        /// <param name="sourceAlternateIdentity"> The alternate identity of the source of the call if dialing out to a pstn number. </param>
        /// <param name="subject"> The subject. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targets"/>, <paramref name="source"/>, <paramref name="callbackUri"/>, <paramref name="requestedModalities"/>, or <paramref name="requestedCallEvents"/> is null. </exception>
        public Response<CreateCallResponse> CreateCall(IEnumerable<CommunicationIdentifierModel> targets, CommunicationIdentifierModel source, string callbackUri, IEnumerable<CallModality> requestedModalities, IEnumerable<EventSubscriptionType> requestedCallEvents, PhoneNumberIdentifierModel sourceAlternateIdentity = null, string subject = null, CancellationToken cancellationToken = default)
        {
            if (targets == null)
            {
                throw new ArgumentNullException(nameof(targets));
            }
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (callbackUri == null)
            {
                throw new ArgumentNullException(nameof(callbackUri));
            }
            if (requestedModalities == null)
            {
                throw new ArgumentNullException(nameof(requestedModalities));
            }
            if (requestedCallEvents == null)
            {
                throw new ArgumentNullException(nameof(requestedCallEvents));
            }

            using var message = CreateCreateCallRequest(targets, source, callbackUri, requestedModalities, requestedCallEvents, sourceAlternateIdentity, subject);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    {
                        CreateCallResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = CreateCallResponse.DeserializeCreateCallResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateHangupCallRequest(string callId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/calling/calls/", false);
            uri.AppendPath(callId, true);
            uri.AppendPath("/Hangup", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Hangup a call. </summary>
        /// <param name="callId"> Call id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="callId"/> is null. </exception>
        public async Task<Response> HangupCallAsync(string callId, CancellationToken cancellationToken = default)
        {
            if (callId == null)
            {
                throw new ArgumentNullException(nameof(callId));
            }

            using var message = CreateHangupCallRequest(callId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Hangup a call. </summary>
        /// <param name="callId"> Call id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="callId"/> is null. </exception>
        public Response HangupCall(string callId, CancellationToken cancellationToken = default)
        {
            if (callId == null)
            {
                throw new ArgumentNullException(nameof(callId));
            }

            using var message = CreateHangupCallRequest(callId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteCallRequest(string callId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/calling/calls/", false);
            uri.AppendPath(callId, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Delete a call. </summary>
        /// <param name="callId"> Call id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="callId"/> is null. </exception>
        public async Task<Response> DeleteCallAsync(string callId, CancellationToken cancellationToken = default)
        {
            if (callId == null)
            {
                throw new ArgumentNullException(nameof(callId));
            }

            using var message = CreateDeleteCallRequest(callId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Delete a call. </summary>
        /// <param name="callId"> Call id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="callId"/> is null. </exception>
        public Response DeleteCall(string callId, CancellationToken cancellationToken = default)
        {
            if (callId == null)
            {
                throw new ArgumentNullException(nameof(callId));
            }

            using var message = CreateDeleteCallRequest(callId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePlayAudioRequest(string callId, string audioFileUri, bool? loop, string operationContext, string audioFileId, string callbackUri)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/calling/calls/", false);
            uri.AppendPath(callId, true);
            uri.AppendPath("/PlayAudio", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var model = new PlayAudioRequest()
            {
                AudioFileUri = audioFileUri,
                Loop = loop,
                OperationContext = operationContext,
                AudioFileId = audioFileId,
                CallbackUri = callbackUri
            };
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(model);
            request.Content = content;
            return message;
        }

        /// <summary> Play audio in a call. </summary>
        /// <param name="callId"> The call id. </param>
        /// <param name="audioFileUri">
        /// The media resource uri of the play audio request.
        /// 
        /// Currently only Wave file (.wav) format audio prompts are supported.
        /// 
        /// More specifically, the audio content in the wave file must be mono (single-channel),
        /// 
        /// 16-bit samples with a 16,000 (16KHz) sampling rate.
        /// </param>
        /// <param name="loop"> The flag indicating whether audio file needs to be played in loop or not. </param>
        /// <param name="operationContext"> The value to identify context of the operation. </param>
        /// <param name="audioFileId"> An id for the media in the AudioFileUri, using which we cache the media resource. </param>
        /// <param name="callbackUri"> The callback Uri to receive PlayAudio status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="callId"/> is null. </exception>
        public async Task<Response<PlayAudioResponse>> PlayAudioAsync(string callId, string audioFileUri = null, bool? loop = null, string operationContext = null, string audioFileId = null, string callbackUri = null, CancellationToken cancellationToken = default)
        {
            if (callId == null)
            {
                throw new ArgumentNullException(nameof(callId));
            }

            using var message = CreatePlayAudioRequest(callId, audioFileUri, loop, operationContext, audioFileId, callbackUri);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    {
                        PlayAudioResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = PlayAudioResponse.DeserializePlayAudioResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Play audio in a call. </summary>
        /// <param name="callId"> The call id. </param>
        /// <param name="audioFileUri">
        /// The media resource uri of the play audio request.
        /// 
        /// Currently only Wave file (.wav) format audio prompts are supported.
        /// 
        /// More specifically, the audio content in the wave file must be mono (single-channel),
        /// 
        /// 16-bit samples with a 16,000 (16KHz) sampling rate.
        /// </param>
        /// <param name="loop"> The flag indicating whether audio file needs to be played in loop or not. </param>
        /// <param name="operationContext"> The value to identify context of the operation. </param>
        /// <param name="audioFileId"> An id for the media in the AudioFileUri, using which we cache the media resource. </param>
        /// <param name="callbackUri"> The callback Uri to receive PlayAudio status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="callId"/> is null. </exception>
        public Response<PlayAudioResponse> PlayAudio(string callId, string audioFileUri = null, bool? loop = null, string operationContext = null, string audioFileId = null, string callbackUri = null, CancellationToken cancellationToken = default)
        {
            if (callId == null)
            {
                throw new ArgumentNullException(nameof(callId));
            }

            using var message = CreatePlayAudioRequest(callId, audioFileUri, loop, operationContext, audioFileId, callbackUri);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    {
                        PlayAudioResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = PlayAudioResponse.DeserializePlayAudioResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCancelAllMediaOperationsRequest(string callId, string operationContext)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/calling/calls/", false);
            uri.AppendPath(callId, true);
            uri.AppendPath("/CancelMediaProcessing", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var model = new CancelAllMediaOperationsRequest()
            {
                OperationContext = operationContext
            };
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(model);
            request.Content = content;
            return message;
        }

        /// <summary> Cancel Media Processing. </summary>
        /// <param name="callId"> The call id. </param>
        /// <param name="operationContext"> The context for this operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="callId"/> is null. </exception>
        public async Task<Response<CancelAllMediaOperationsResponse>> CancelAllMediaOperationsAsync(string callId, string operationContext = null, CancellationToken cancellationToken = default)
        {
            if (callId == null)
            {
                throw new ArgumentNullException(nameof(callId));
            }

            using var message = CreateCancelAllMediaOperationsRequest(callId, operationContext);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CancelAllMediaOperationsResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = CancelAllMediaOperationsResponse.DeserializeCancelAllMediaOperationsResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Cancel Media Processing. </summary>
        /// <param name="callId"> The call id. </param>
        /// <param name="operationContext"> The context for this operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="callId"/> is null. </exception>
        public Response<CancelAllMediaOperationsResponse> CancelAllMediaOperations(string callId, string operationContext = null, CancellationToken cancellationToken = default)
        {
            if (callId == null)
            {
                throw new ArgumentNullException(nameof(callId));
            }

            using var message = CreateCancelAllMediaOperationsRequest(callId, operationContext);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CancelAllMediaOperationsResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = CancelAllMediaOperationsResponse.DeserializeCancelAllMediaOperationsResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateInviteParticipantsRequest(string callId, IEnumerable<CommunicationIdentifierModel> participants, PhoneNumberIdentifierModel alternateCallerId, string operationContext, string callbackUri)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/calling/calls/", false);
            uri.AppendPath(callId, true);
            uri.AppendPath("/participants", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var model = new InviteParticipantsRequestInternal(participants.ToList())
            {
                AlternateCallerId = alternateCallerId,
                OperationContext = operationContext,
                CallbackUri = callbackUri
            };
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(model);
            request.Content = content;
            return message;
        }

        /// <summary> Invite participants to the call. </summary>
        /// <param name="callId"> Call id. </param>
        /// <param name="participants"> The list of participants to be added to the call. </param>
        /// <param name="alternateCallerId"> The alternate identity of source participant. </param>
        /// <param name="operationContext"> The operation context. </param>
        /// <param name="callbackUri"> The callback URI. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="callId"/> or <paramref name="participants"/> is null. </exception>
        public async Task<Response> InviteParticipantsAsync(string callId, IEnumerable<CommunicationIdentifierModel> participants, PhoneNumberIdentifierModel alternateCallerId = null, string operationContext = null, string callbackUri = null, CancellationToken cancellationToken = default)
        {
            if (callId == null)
            {
                throw new ArgumentNullException(nameof(callId));
            }
            if (participants == null)
            {
                throw new ArgumentNullException(nameof(participants));
            }

            using var message = CreateInviteParticipantsRequest(callId, participants, alternateCallerId, operationContext, callbackUri);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Invite participants to the call. </summary>
        /// <param name="callId"> Call id. </param>
        /// <param name="participants"> The list of participants to be added to the call. </param>
        /// <param name="alternateCallerId"> The alternate identity of source participant. </param>
        /// <param name="operationContext"> The operation context. </param>
        /// <param name="callbackUri"> The callback URI. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="callId"/> or <paramref name="participants"/> is null. </exception>
        public Response InviteParticipants(string callId, IEnumerable<CommunicationIdentifierModel> participants, PhoneNumberIdentifierModel alternateCallerId = null, string operationContext = null, string callbackUri = null, CancellationToken cancellationToken = default)
        {
            if (callId == null)
            {
                throw new ArgumentNullException(nameof(callId));
            }
            if (participants == null)
            {
                throw new ArgumentNullException(nameof(participants));
            }

            using var message = CreateInviteParticipantsRequest(callId, participants, alternateCallerId, operationContext, callbackUri);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateRemoveParticipantRequest(string callId, string participantId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/calling/calls/", false);
            uri.AppendPath(callId, true);
            uri.AppendPath("/participants/", false);
            uri.AppendPath(participantId, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Remove participant from the call. </summary>
        /// <param name="callId"> Call id. </param>
        /// <param name="participantId"> Participant id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="callId"/> or <paramref name="participantId"/> is null. </exception>
        public async Task<Response> RemoveParticipantAsync(string callId, string participantId, CancellationToken cancellationToken = default)
        {
            if (callId == null)
            {
                throw new ArgumentNullException(nameof(callId));
            }
            if (participantId == null)
            {
                throw new ArgumentNullException(nameof(participantId));
            }

            using var message = CreateRemoveParticipantRequest(callId, participantId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Remove participant from the call. </summary>
        /// <param name="callId"> Call id. </param>
        /// <param name="participantId"> Participant id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="callId"/> or <paramref name="participantId"/> is null. </exception>
        public Response RemoveParticipant(string callId, string participantId, CancellationToken cancellationToken = default)
        {
            if (callId == null)
            {
                throw new ArgumentNullException(nameof(callId));
            }
            if (participantId == null)
            {
                throw new ArgumentNullException(nameof(participantId));
            }

            using var message = CreateRemoveParticipantRequest(callId, participantId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
